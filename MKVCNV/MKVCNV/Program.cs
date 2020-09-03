using System;

namespace MKVCNV
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "Certificates and public key infrastructure (PKI) are hard. No shit, right? I know a lot of smart people who've avoided this particular rabbit hole. Personally, I avoided it for a long time and felt some shame for not knowing more. The obvious result was a vicious cycle: I was too embarrassed to ask questions so I never learned. Eventually I was forced to learn this stuff because of what it enables: PKI lets you define a system cryptographically.It's universal and vendor neutral. It works everywhere so bits of your system can run anywhere and communicate securely. It's conceptually simple and super flexible. It lets you use TLS and ditch VPNs. You can ignore everything about your network and still have strong security characteristics. It's pretty great. Now that I have learned, I regret not doing so sooner. PKI is really powerful, and really interesting.The math is complicated, and the standards are stupidly baroque, but the core concepts are actually quite simple.Certificates are the best way to identify code and devices, and identity is super useful for security, monitoring, metrics, and a million other things.Using certificates is not that hard.No harder than learning a new language or database. It's just slightly annoying and poorly documented. This is the missing manual.I reckon most engineers can wrap their heads around all the most important concepts and common quirks in less than an hour.That's our goal here. An hour is a pretty small investment to learn something you literally can't do any other way.";
            
            MarkovLanguage ml = new MarkovLanguage();
            foreach (string sentance in source.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries))
            {
                ml.AddSentance(sentance);
            }
            Console.Write($"{ml.GenerateSentance()} ");

        }
    }
}
