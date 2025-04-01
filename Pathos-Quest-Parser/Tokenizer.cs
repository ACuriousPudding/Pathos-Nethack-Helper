using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Pathos_Nethack_Helper.PathosQuestParser
{
    public class Tokenizer
    {
        private string FilePath = "";

        // Constructor
        public Tokenizer(string filePath)
        {
            this.FilePath = filePath;
        }
        
        public void Parse()
        {
            Console.WriteLine("Tokenizer.Parse() not fully implemented.");
            // Read the file and tokenize the lines
            this.ParseFile();

            // Create TokenGroups from the tokenized lines
        }

        private List<List<string>> ParseFile()
        {
            Console.WriteLine("Tokenizer.ParseFile() called");
            // Initialize a nested list of token lists. Each list models a line of the .Quest file.
            List<List<string>> tokenizedLines = new List<List<string>>();
            // Read the file line by line, tokenizing each line and inserting it into the list
            foreach (string line in File.ReadLines(this.FilePath))
            {
                Console.WriteLine($"Reading line: {line}");
                Console.WriteLine($"Parsed Line: {this.ParseLine(line)}");
            }

            return tokenizedLines;
        }

        private List<string> ParseLine(string line)
        {
            Console.WriteLine("Tokenizer.ParseLine() called.");
            List<string> tokens = new List<string>();

            string currentToken = "";
            bool inBrackets = false;
            foreach (char c in line)
            {
                // When the character is an opening bracket, we want to escape any whitespace inside it
                if (c == '[' && !inBrackets)
                {
                    inBrackets = true;
                    // If a current token exists, finalize it and start a new one
                    if (!string.IsNullOrEmpty(currentToken) && currentToken != "@")
                    {
                        tokens.Add(currentToken);
                        currentToken = c.ToString();
                    } else {
                        // Start a new token with the '[' character
                        currentToken += c.ToString();
                    }
                    continue;
                }
                if (c == ']' && inBrackets)
                {
                    // When the character is a closing bracket AND we're inside brackets, finalize the token
                    currentToken += c.ToString();
                    tokens.Add(currentToken);
                    currentToken = "";
                    continue;
                }
                if ((c == ' ' || c == ';') && !inBrackets)
                {
                    // If we encounter a space or semicolon and we're not in brackets, finalize the current token
                    if (!string.IsNullOrEmpty(currentToken) && currentToken != "@")
                    {
                        tokens.Add(currentToken);
                        currentToken = "";
                    }
                    continue;
                }
                // Otherwise, keep building the current token
                currentToken += c.ToString();
            }
            // Finalize the last token if it exists
            if (!string.IsNullOrEmpty(currentToken))
            {
                tokens.Add(currentToken);
            }

            return tokens;
        }

        private Dictionary<string, TokenGroup> ProcessTokens()
        {
            Console.WriteLine("Tokenizer.ProcessTokens() not implemented.");
            return new Dictionary<string, TokenGroup>();
        }
    }
}