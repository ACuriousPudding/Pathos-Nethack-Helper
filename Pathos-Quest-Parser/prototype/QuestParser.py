import re
import os

class QuestParser:
    def __init__(self):
        pass

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
    
    def parse(self, filepath):
        print("parse() not implemented.")
        pass

    def parse_tokens(self):
        """
        Parses the tokenized Quest file and returns a structured representation of the tokens.
        :return: A structured representation of the tokens. TODO: define structure
        """
        print("parse_tokens() not implemented.")
        pass

    def parse_file(self):
        """
        Parses the input Quest file and returns list of lists of tokens.
        :param filepath: The input file to parse.
        :return: A list of lists of tokens.
        """
        self.parsed_data = []
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
                        self.parsed_data.append(tokens)

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
    


if __name__ == "__main__":
    # Example usage
    qp = QuestParser()
    qp.set_filepath("Chambers.Quest")
    filepath = qp.get_filepath()

    qp.parse(filepath)

    for line in qp.get_parsed_data():
        print(f"Parsed line: {line}")
        
    
