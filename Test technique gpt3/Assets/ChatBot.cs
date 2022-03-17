using UnityEngine;
using OpenAI_API;
using System.Threading.Tasks;
using UnityEngine.UI;

public class ChatBot : MonoBehaviour 
{
    [SerializeField] private string _Apikey;
    [SerializeField] private Bot bot;
    private string iBriefing;
    OpenAIAPI api;

    [SerializeField] private InputField inputField;

    public void Send()
    {
        var task = RespondAsync();
    }

    public async Task RespondAsync()
    {
        if (inputField.text == "" || inputField.text == null)
        {
            bot.ChangeEmotion(0);
            return;
        }
        iBriefing = "Is the sentence \"" + inputField.text + "\" positive? Answer by yes or no:";
        api = new OpenAIAPI(_Apikey, new Engine("text-davinci-001"));
        var result = await api.Completions.CreateCompletionAsync(
                                                                   iBriefing,
                                                                   max_tokens: 100,
                                                                   temperature: 1,
                                                                   top_p: 0,
                                                                   frequencyPenalty: 0,
                                                                   presencePenalty: 0);

        string str = YesOrNoParser(result.ToString());
        if (str == "Yes")
        {
            bot.ChangeEmotion(1);
        } else if (str == "No")
        {
            bot.ChangeEmotion(-1);
        } else
        {
            bot.ChangeEmotion(0);    
        }

    }

    private  string YesOrNoParser(string str)
    {
        if (str == null)
            return "";
        return str.Replace("\n", string.Empty);
    }
}
