using System;
using System.Collections.Generic;

public class CodingGame
{
    private readonly Dictionary<int, string> _languageOptions = new Dictionary<int, string>()
    {
        { 1, "Python 2" },
        { 2, "Python 3" },
        { 3, "Java" },
        { 4, "JavaScript" },
        { 5, "C" },
        { 6, "C++" },
        { 7, "C#" },
        { 8, "HTML" },
        { 9, "CSS" },
        { 10, "F#" }
    };

    private readonly List<Challenge>[] _challengesByLanguage;

    public CodingGame()
    {
        _challengesByLanguage = new List<Challenge>[11]; // One list for each language, indexed by language ID
        for (int i = 0; i < 11; i++)
        {
            _challengesByLanguage[i] = new List<Challenge>();
        }
        // Add challenges for each programming language
        AddChallenges();
    }

    public void RunChallenge(int language, int level)
    {
        if (!_languageOptions.ContainsKey(language))
        {
            Console.WriteLine("Invalid Language!");
            return;
        }

        if (level < 1 || level > 100)
        {
            Console.WriteLine("Invalid Level!");
            return;
        }

        var languageName = _languageOptions[language];
        var challengeList = _challengesByLanguage[language];
        var index = level - 1;
        if (index >= challengeList.Count)
        {
            Console.WriteLine($"No challenge available for level {level} in {languageName}.");
            return;
        }

        var challenge = challengeList[index];
        Console.WriteLine($"Language: {languageName}, Level: {level}");
        Console.WriteLine($"Description: {challenge.Description}");

        // Get user code
        string code = GetCodeInput();

        // Execute and verify code
        bool success = VerifyCode(code, challenge.ExpectedOutput);

        Console.WriteLine(success ? "Success!" : "Incorrect Output. Try again.");

        if (!success && level > 10) // Provide hints for advanced levels
        {
            Console.WriteLine("Hint: " + challenge.Hint);
        }
    }

    private string GetCodeInput()
    {
        Console.WriteLine("Enter your code:");
        return Console.ReadLine();
    }

    private bool VerifyCode(string code, string expectedOutput)
    {
        // In a real implementation, this method would execute the provided code
        // and compare the output with the expected output.
        // For simplicity, we'll just compare the provided code with the expected output here.
        return code.Trim() == expectedOutput.Trim();
    }

    private void AddChallenges()
    {
        // Add challenges for each programming language
        // For demonstration purposes, we'll add placeholder challenges
        for (int language = 1; language <= 10; language++)
        {
            for (int i = 0; i < 100; i++)
            {
                _challengesByLanguage[language].Add(new Challenge
                {
                    Description = $"Challenge {i + 1} description in {_languageOptions[language]}",
                    ExpectedOutput = $"Expected output for challenge {i + 1} in {_languageOptions[language]}",
                    Hint = $"Hint for challenge {i + 1} in {_languageOptions[language]}"
                });
            }
        }
    }
}

public class Challenge
{
    public string Description { get; set; }
    public string ExpectedOutput { get; set; }
    public string Hint { get; set; } // Optional for advanced levels
}

class Program
{
    static void Main(string[] args)
    {
        CodingGame game = new CodingGame();
        int language, level;

        do
        {
            Console.WriteLine("Choose programming language (1-10) or 0 to exit:");
            language = int.Parse(Console.ReadLine());
            if (language > 0)
            {
                Console.WriteLine("Choose challenge level (1-100) or 0 to exit:");
                level = int.Parse(Console.ReadLine());
                if (level > 0)
                {
                    game.RunChallenge(language, level);
                }
            }
        } while (language != 0);
    }
}
