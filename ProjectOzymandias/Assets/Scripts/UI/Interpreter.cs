using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Interpreter : MonoBehaviour
{
    private int whoami;
    private int whatdoyouremember;

    Dictionary<string, string> colors = new Dictionary<string, string>()
    {
        {"black", "#021b21"},
        {"gray", "#555d71"},
        {"red", "#ff5879"},
        {"yellow", "#f2f1b9"},
        {"blue", "#9ed9d8"},
        {"purple", "#d926ff"},
        {"orange", "#ef5847"}
    };

    List<string> response = new List<string>();

    public List<string> Interpret(string userInput)
    {
        response.Clear();
        string[] args = userInput.Split();

        if (args[0] == "help")
        {
            ListEntry("help", "returns a list of commands");
            ListEntry("stop", "pauses the game");
            ListEntry("run", "resumes the game");
            ListEntry("four", "blah, blah, blah");
        }

        if (args[0] == "oswaldbrowne")
        {
            ListEntry("Name", "Dr Oswald Browne");
            ListEntry("Date of Birth", "15-01-1913");
            ListEntry("Bio", "Dr. Oswald Browne holds a Ph.D. in Neuroscience, he is fascinated by the human");
            ListEntry("1", "brain. Oswald has always maintained a strong ethical compass, advocating for");
            ListEntry("2", "responsible use of his theoretical technology. His works led to significant");
            ListEntry("3", "development in brain-computer interfaces, earning him numerous awards and a");
            ListEntry("4", "prestigious position in the facility");
            ListEntry("-", "");
            ListEntry("5", "Dr. Oswald has mentored many young scientists and has even hand selected");
            ListEntry("7", "one of the brilliant scientists that he encountered through his years of");
            ListEntry("8", "teaching. Outside of work, Oswald enjoys poetry and classical music, has no");
            ListEntry("9", "children or close relatives.");
        }

        if (args[0] == "michealweiss")
        {
            ListEntry("Name", "Dr Micheal Weiss");
            ListEntry("Date of Birth", "12-08-1936");
            ListEntry("Bio", "Dr. Micheal Weiss holds a Ph.D in Computer Science and Robotics. He has");
            ListEntry("1", "made significant contributions to developments in AI systems that mimic human functions.");
            ListEntry("2", "Early in his career, he met Dr. Oswald Browne which started a profound");
            ListEntry("3", "mentorship and friendship. Dr. Weiss created the robots which roam the facility and ");
            ListEntry("4", "Project Apex before moving on to work on Project Ozymandias. ");
            ListEntry("-", "");
            ListEntry("5", "Dr. Micheal Weiss is described as being extremely ambitious and has always");
            ListEntry("6", "tried to push the boundries of technology, sometimes being at odds with");
            ListEntry("7", "the more cautious elements of the scientific community. Dr. Weiss has a");
            ListEntry("8", "daughter named Julia.");
            ListEntry("9", "Micheal's father was a german scientist, brought over to the United States");
            ListEntry("10", "after World War II, during Operation Paperclip. Micheal decided to become");
            ListEntry("11", "a scientist much like his father. His father died from a heart attack in ");
            ListEntry("12", "1965, while working in the pentagon.");
        }

        if (args[0] == "void")
        {
            ListEntry("Subject", "The Void Incident");
            ListEntry("Date", "19-02-1967");
            ListEntry("Description", "A devistating event has recently occured at a government");
            ListEntry("1", "facility in the late hours of Friday night. Two scientists were caught");
            ListEntry("2", "in an explosion with experimental technology, leaving behind nothing but");
            ListEntry("3", "ruin and questions. ");
            ListEntry("-", "");
            ListEntry("4", "Dr. Micheal Weiss and Dr. Oswald Browne were the only fatalities, as the");
            ListEntry("5", "accident occured after work hours. There are plenty of questions that are");
            ListEntry("6", "still to be asked such as, how did this happen?, and where are the");
            ListEntry("7", "bodies of the doctors?. Dr. Micheal Weiss leaves behind a 3 year old");
            ListEntry("8", "daughter named Julia");
            ListEntry("9", "Thats all for this morning");
            ListEntry("9", "- KNMW News 12 New Mexico");
        }

        if (args[0] == "projectapex")
        {
            ListEntry("Name", "Project Apex");
            ListEntry("Description", "Project Apex was set up to create a soldier which could potentially");
            ListEntry("1", "replace humans on the battlefield. It was set up specifically for the Vietnam");
            ListEntry("2", "war, and is fully funded by the government. The project was shut down after");
            ListEntry("3", "the void incident, leaving behind empty skeletons of varying condition.");
        }


        if (args[0] == "meed")
        {
            ListEntry("Name", "MEED (Mind Exchange and Embedding Device)");
            ListEntry("Description", "Experimental Device placed on a users head to copy part");
            ListEntry("1", "of their consciousness. Used with an NCI.");
        }

        if (args[0] == "nci")
        {
            ListEntry("Name", "NCI (Neural-Consciousness Interface)");
            ListEntry("Description", "Experimental interface that allows for digital consciousness to");
            ListEntry("1", "connect with devices, databases, etc.");
        }


        if (args[0] == "repulse")
        {
            ListEntry("Name", "Repulse grenade V2");
            ListEntry("Description", "Experimental weapon. Emits a large gravity wave,");
            ListEntry("1", "pushing back anything in its vacinity. Unlike V1 which did the opposite.");
            ListEntry("2", "V1 scrapped after the Void Incident.");
        }

        if (args[0] == "ozymandiasdoc.txt")
        {
            ListEntry("Name", "Project Ozymandias");
            ListEntry("Phase 1", "The process starts by connecting the MEED Device to the NCI,");
            ListEntry("1", "The MEED Device then initiated a comprehensive scan of the brain, identifying");
            ListEntry("2", "and mapping neural pathways associated with memories. After this process,");
            ListEntry("3", "the system then starts transfering these memories into the NCI.");
            ListEntry("4", "This is achieved by digitalizing neural patterns and storing them within");
            ListEntry("5", "the NCI's secure memory banks.");
            ListEntry("Phase 2", "Upon success of phase 1, phase 2 begins. The MEED Device will upload");
            ListEntry("7", "congitive patterns that relate to identity, and self-awareness - making");
            ListEntry("8", "the user know who they are. Any feeling of confusion or lack of identity");
            ListEntry("9", "may be caused due to an interruption in phase 1, or an error in syncing");
            ListEntry("10", "phase 1 to phase 2 (This may happen if muliple people have a MEED device");
            ListEntry("11", "on their heads)");
            ListEntry("12", "There are many safety and ethical concerns such as endless control over");
            ListEntry("13", "massive networks of technology, if user has access to large amounts");
            ListEntry("14", "of hardware.");
        }

        if (args[0] == "2159")
        {
            ListEntry("Date", "18-02-1967");
            ListEntry("Subject", "MEED Device Test 1");
            ListEntry("By", "Dr. Oz");
            ListEntry("1", "Today marks a monumentous occasion in the journey of Project Ozymandias, ");
            ListEntry("2", "Today, I will attempt to upload a fragment of my own consciousness");
            ListEntry("3", "onto the NCI, by using the MEED device. I only hope that my efforts toady");
            ListEntry("4", "will contribute to a better understanding, and not a tale of overreach.");
            ListEntry("5", "Here's to the unknown.");
            ListEntry("6", "- Dr. Oz");
            ListEntry("7", "(Test results will be automatically uploaded to desktop)");
        }

        if (args[0] == "rslt1.txt")
        {
            ListEntry("Date", "18-02-1967");
            ListEntry("Test", "MEED Device Test 1");
            ListEntry("Result", "Success");
            ListEntry("Phase 1", "Success");
            ListEntry("Phase 2", "Error");
            ListEntry("Error list", "User disconnected at 62% progress; Do you want to abort?");
            ListEntry("Response", "Continue");
            ListEntry("Error list", "Different user detected; May cause confusion and fusion");
            ListEntry("2", "of memories and/or consciousness; Do you want to abort?");
            ListEntry("Response", "Continue");
            ListEntry("Phase 2", "Success");
            ListEntry("Message", "Hello Doctor Oz and Doctor Weiss.");
            ListEntry("Error", "Power lost. Shutting down.");
        }

        if (args[0] == "ozymandias")
        {
            ListEntry("1", "I met a traveller from an antique land,");
            ListEntry("2", "Who said—Two vast and trunkless legs of stone");
            ListEntry("3", "Stand in the desert. . . . Near them, on the sand,");
            ListEntry("4", "Half sunk a shattered visage lies, whose frown, ");
            ListEntry("5", "And wrinkled lip, and sneer of cold command,");
            ListEntry("6", "Tell that its sculptor well those passions read");
            ListEntry("7", "Which yet survive, stamped on these lifeless things,");
            ListEntry("8", "The hand that mocked them, and the heart that fed;");
            ListEntry("9", "And on the pedestal, these words appear:");
            ListEntry("10", "My name is Ozymandias, King of Kings;");
            ListEntry("11", "Look on my Works, ye Mighty, and despair!");
            ListEntry("12", "Nothing beside remains. Round the decay");
            ListEntry("13", "Of that colossal Wreck, boundless and bare");
            ListEntry("14", "The lone and level sands stretch far away.");
        }

        if (args[0] == "projectozymandias")
        {
            ListEntry("Project Name", "Project Ozymandias");
            ListEntry("Project Description", "Reserach initiative spearheaded by Dr. Oz,");
            ListEntry("1", "aims to explore consciousness transference into a digital framework.");
            ListEntry("2", "Named after the poem - Ozymandias by Percy Shelley - and the leader ");
            ListEntry("3", "of the research, Dr. Oz, the project aims to achieve full digitalization");
            ListEntry("4", "of memories, with ensured preservation of personality and feeling.");
            ListEntry("5", "Other reserachers assigned to Project Ozymandias are;");
            ListEntry("6", "Dr. Elijah Ali, Dr. Micheal Weiss, and Dr. Marie Hummells.");
            ListEntry("7", "For more information, see the Project documentation.");
            ListEntry("8", "(ozymandiasdoc.txt).");
        }

        if (args[0] == "eclipse")
        {
            ListEntry("Date", "18-02-1967");
            ListEntry("Subject", "Urgent: Directive on Project Ozymandias");
            ListEntry("By", "REDACTED");
            ListEntry("1", "Dear [REDACTED], ");
            ListEntry("2", "I understand that you are aware of the urgency and delicate nature of the operation.");
            ListEntry("3", "Project Ozymandias represents a significant leap in our capabilities, holding the");
            ListEntry("4", "potential to change the balance of power in the favor of our country. It is unfortunate");
            ListEntry("5", "that Dr. Oz does share the same vision as we in the [REDACTED] do.");
            ListEntry("6", "Given your proven expertise and loyalty, you have been tasked with two objectives;");
            ListEntry("7", "Neutralize Dr. Oz,");
            ListEntry("8", "Secure Project Ozymandias.");
            ListEntry("9", "The stakes could not be higher, We expect to hear from you in 24 hours.");
            ListEntry("10", "The future of national security could be ensured, do your father proud.");
            ListEntry("11", "Good Luck,");
            ListEntry("12", "[REDACTED]");
        }

        if (args[0] == "What do you remember?")
        {
            if (whatdoyouremember == 0)
            {
                ListEntry("1", "I remember nothing");
                whatdoyouremember = 1;
            }

            else if (whatdoyouremember == 1)
            {
                ListEntry("1", "I remember a void");
                ListEntry("1", "I remember an eclipse");
            }
        }

        if (args[0] == "Who are you?")
        {
            if(whoami == 0)
            {
                ListEntry("1", "I dont't know");
                whoami = 1;
            }

            else if (whoami == 1)
            {
                ListEntry("1", "I am Ozymandias");
            }
        }


        if (args[0] == "170267")
        {
            ListEntry("Date", "17-02-1967");
            ListEntry("Subject", "The Future of Project Ozymandias");
            ListEntry("By", "Dr. Weiss");
            ListEntry("1", "The closer I get to the heart of Project Ozymandias, the more I see its wasted");
            ListEntry("2", "potential in Dr. Oz's hands. The pentagon, with their endless hunger for");
            ListEntry("3", "control, sees an opportunity in Oz's naivety. They've approached me, a proposition ");
            ListEntry("4", "cloaked in national security, to wrest control of Ozymandias from Oz.");
            ListEntry("5", "They see a weapon. I see a key, a key to a new world order, an era shaped by my design.");
            ListEntry("-", "");
            ListEntry("6", "Dr. Oz may have birthed Ozymandias, but he lacks the will to push it beyond the ");
            ListEntry("7", "theoretical. I will not make the same mistake. The government believes they are ");
            ListEntry("7", "using me as their instrument, a simple means to an end. Fools. They are but a ");
            ListEntry("8", "stepping stone, providing me with the access and resources I need. Once I have ");
            ListEntry("9", "control of Ozymandias, the chessboard will be mine to command.");
            ListEntry("-", "");
            ListEntry("10", "Imagine—a world where every device, every system, is an extension of my will. ");
            ListEntry("11", "The dawn of a new civilization is upon us, and I am its architect.");
            ListEntry("12", "Dr. Weiss");
        }



        if (args[0] == "boop")
        {
            response.Add("Thank you for using this terminal.");
            return response;
        }
        else
        {
            response.Add("Command not recognized. Type help for a list of commands.");

            return response;
        }
    }
    public string ColorString(string s, string color)
    {
        string leftTag = "<color=" + color + ">";
        string rightTag = "</color>";

        return leftTag + s + rightTag;
    }

    void ListEntry(string a, string b)
    {
        response.Add(ColorString(a, colors["orange"]) + ": " + ColorString(b, colors["yellow"]));
    }

    void LoadTitle(string path, string color, int spacing)
    {
        StreamReader file = new StreamReader(Path.Combine(Application.streamingAssetsPath, path));

        for(int i = 0; i < spacing; i++)
        {
            response.Add("");
        }
















        while(!file.EndOfStream)
        {
            response.Add(ColorString(file.ReadLine(), colors[color]));
        }

        for(int i = 0; i < spacing; i++)
        {
            response.Add("");
        }

        file.Close();
    }
}


