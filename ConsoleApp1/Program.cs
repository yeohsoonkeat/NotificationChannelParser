using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        String? input;
        do
        {
            Console.WriteLine("Notification title Input:");
            input = Console.ReadLine();
            if (input != null)
            {
                Console.WriteLine(ParseNotificationChannels(input.Trim()));
            }
        } while (input == null);
    }

    static string ParseNotificationChannels(string title)
    {
        List<string> validChannels = new List<string> { "BE", "FE", "QA", "Urgent" };
        HashSet<string> foundChannels = new HashSet<string>();

        // Regex to detect differnet channels from string
        Regex tagPattern = new Regex(@"\[(.*?)\]");
        MatchCollection matches = tagPattern.Matches(title);

        // Loop matches and check if they are valid channels
        foreach (Match match in matches)
        {
            string tag = match.Groups[1].Value;
            if (validChannels.Contains(tag))
            {
                foundChannels.Add(tag);
            }
        }
        string output = "Receive channels: " + string.Join(", ", foundChannels);
        return output;
    }
}
