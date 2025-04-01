import re
import os

class Tokenizer:
    

    def __init__(self):
        self.filepath = ''
        self.tokenized_data = []
        self.parsed_data = None
        print("Tokenizer initialized. Set the filepath with set_filepath() method before calling parse().")

    def set_filepath(self, filepath):
        """
        Sets the file path for the parser to process.
        Throws FileNotFoundError if the file does not exist.
        :param filepath: The absolute or relative path to the Quest file to be parsed.
        :return: None
        """
        print(f"Set filepath to: {filepath}")
        # TODO: Check if filepath exists
        if not os.path.exists(filepath):
            raise FileNotFoundError(f"The file {filepath} does not exist.")
        self.filepath = filepath

    def get_filepath(self):
        """
        Returns the current file path set in the parser.
        :return: The file path as a string.
        """
        try:
            return self.filepath
        except AttributeError:
            print("Filepath not set. Please set the filepath before getting it.")
            return None
    
    def get_tokenized_data(self):
        # This is a method for debugging purposes
        return self.tokenized_data

    def get_parsed_data(self):
        """
        Returns the parsed data from the Quest file.
        :return: The parsed data, which is a collection of tokens.
        """
        try:
            return self.parsed_data
        except AttributeError:
            print("Parsed data not available. Run parse() method first.")
            return None
    
    def parse(self):
        # Parse the file, breaking into a tokenized list
        self.parse_file()
        # Parse the tokenized list, grouping related token sets and creating structures
        quest = self.parse_tokens()

        return quest

    def parse_file(self):
        """
        Parses the input Quest file and returns list of lists of tokens.
        :param filepath: The input file to parse.
        :return: A list of lists of tokens.
        """
        # Erase the previous tokenized data
        if self.tokenized_data:
            print("Warning: Previous tokenized data will be erased.")
        self.tokenized_data = []
        try:
            with open(self.filepath, 'r') as file:
                lines = file.readlines()
                for line in lines:
                    # Process each line using the parse_line method
                    tokens = self.parse_line(line.strip())
                    if tokens is None:
                        print(f"Warning: parse_line found no tokens for line: {line.strip()}. Skipping this line.")
                        continue
                    else:
                        # Append the tokens to the parsed_data list
                        self.tokenized_data.append(tokens)

        except FileNotFoundError:
            print(f"Error: The file {self.filepath} was not found. Set filepath before calling parse.")
            return False
        
        return True
    
    def parse_line(self, text):
        """
        Parses a single line of the Quest file and returns a tokenized version of that line.
        :param text: A string representing a single line from the Quest file.
        :return: A list of tokens.

        Example text: character @[000283] [neuter] [large pile of killer coins] noclass square map [Chamber 18] (05,09);
        Expected Output: ['character', '@[000283]', '[neuter]', '[large pile of killer coins]', 'noclass', 'square', 'map', '[Chamber 18]', '(05,09)']
        """
        tokens = []

        current_token = ""
        in_brackets = False
        for char in text:
            if char == '[':
                in_brackets = True
                # If we encounter a '[', finalize the current token if it exists
                if current_token and current_token != '@':
                    tokens.append(current_token)
                    current_token = char
                else:
                    # Start a new token with the '[' character
                    current_token += char
                # Continue to the next character, as we are now in a bracketed section
                continue
            if char == ']':
                in_brackets = False
                # If we encounter a ']', finalize the current token
                current_token += char
                tokens.append(current_token)
                current_token = ""
                continue
            if (char == ' ' or char == ';') and not in_brackets:
                # If we encounter a space and we're not inside brackets, finalize the current token
                if current_token:
                    tokens.append(current_token)
                    current_token = ""
                # Skip the space
                continue
            # Otherwise, we're in the middle of a token, so just add the character to the current_token
            current_token += char
        # Add the last token if there's any remaining text
        if current_token:
            tokens.append(current_token)
        
        return tokens
    

    def parse_tokens(self):
        """
        Parses the tokenized Quest file and returns a structured representation of the tokens.
        :return: A structured representation of the tokens as a Quest object.
        """
        # Initialize Quest object, and set the filepath in the metadata
        quest = Quest()
        quest.metadata['filepath'] = self.filepath

        # Iterate over token list, breaking it into groups delimited by blank lines (empty lists)
        token_groups = []
        current_group = []
        for tokens in self.tokenized_data:
            # Either an empty list or a None type indicate a blank line between groups
            # TODO: Handle the "start" token line, which doesn't have a blank line before it
            if not tokens: 
                token_groups.append(current_group)
                current_group = []
                continue
            else:
                current_group.append(tokens)
        # Append the last group if it exists
        if current_group:
            token_groups.append(current_group)
        
        # Iterate through groups, and assign them to the appropriate data structure
        for group in token_groups:
            # Check the first token of the first list of tokens to determine group type
            first_token = group[0][0]
            if first_token == 'quest' or first_token == '\ufeffquest':
                # The title is the second token in this group
                quest.metadata['title'] = group[0][1]
            elif first_token == 'site':
                quest.sites.append(group)
            elif first_token == 'map':
                quest.maps[group[0][1]] = group
            elif first_token == 'character':
                for character in group:
                    # The player start position is listed in the Character block, so we filter for it here
                    if character[0] == 'start':
                        quest.metadata['start'] = character
                        continue
                    # The character ID is the second token in the list, and we keep the whole list as the value
                    quest.characters[character[1]] = character
            # Fallthrough for any unknown token types
            else:
                print(f"Warning: Unrecognized token type '{first_token}' in group. Skipping this group.")
                continue
        
        # print(f"Parsed data structure:{quest.maps['[Base of The Chamber]']}")
        return quest
    
"""
Data Structures to represent the parsed data.
"""
class Quest:
    """
    Represents a Quest file.
    """
    def __init__(self):
        # Metadata about the Quest file, such as title, filepath, 
        self.metadata = dict()
        # The "site" group contains the list of maps, as well as the name of the site
        self.sites = []
        # Maps are stored with their name as the key, and a dictionary value using the coordinates of cells
        # as keys and an ordered list of contents of the cell as values
        # The order of the contents list indicates stacking order in the cell from ground up.
        self.maps = dict()
        # Characters are stored using the @code ID as their key. These are refered to throughout the file, and
        # are defined as a single large block near the bottom.
        self.characters = dict()
    
    def get_character(self, id):
        """
        Returns the character with the given ID.
        :param id: The ID of the character to retrieve.
        :return: The character object or None if not found.
        """
        return self.characters[id] if id in self.characters else None

    def find_character_by_type(self, type):
        """
        Returns a list of characters of the given type.
        :param type: The type of character to find.
        :return: A list of characters of the given type.
        """
        results = []
        # Field 3 is the name of the monster (the "type")
        for id, character in self.characters.items():
            if character[3] == type:
                results.append(character)
        return results




if __name__ == "__main__":
    # Example usage
    tokenizer = Tokenizer()
    tokenizer.set_filepath("Chambers.Quest")
    filepath = tokenizer.get_filepath()

    chamberQuest = tokenizer.parse()

    # for k in chamberQuest.maps.keys():
    #     print(f"Map: {k}")
    # print()

    # for k in chamberQuest.characters.keys():
    #     print(f"Character: {k}")
    # print()

    # for k in chamberQuest.sites:
    #     print(f"Site: {k}")
    # print()
    
    # character @[000283] [neuter] [large pile of killer coins] noclass square map [Chamber 18] (05,09);
    # print(chamberQuest.get_character('@[000283]'))

    # Find all characters of type "mind flayer"
    for k in chamberQuest.find_character_by_type('[mind flayer]'):
        print(k)