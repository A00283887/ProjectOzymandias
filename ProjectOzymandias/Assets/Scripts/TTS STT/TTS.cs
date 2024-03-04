using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Amazon.Polly;
using Amazon.Runtime;
using Amazon;
using Amazon.Polly.Model;
using System.IO;
using UnityEngine.Networking;
using System.Threading.Tasks;
using TMPro;

public class TTSS : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public GameObject text;
    public string Response;
    public async void TextToSpeech()
    {
        Response = text.GetComponent<TextMeshProUGUI>().text;
        var credentials = new BasicAWSCredentials("AKIA6ODU2CMAIZRNA26O", "Ol/QrtyTiwglmb67qTFmcwMMnjFHe3YuxaSBt9Ko");
        var client = new AmazonPollyClient(credentials, RegionEndpoint.EUCentral1);

        var request = new SynthesizeSpeechRequest()
        {
            Text = Response,
            Engine = Engine.Neural,
            VoiceId = VoiceId.Arthur,
            OutputFormat = OutputFormat.Mp3
        };

        var response = await client.SynthesizeSpeechAsync(request);

        WriteToFile(response.AudioStream);

        using (var www = UnityWebRequestMultimedia.GetAudioClip($"{Application.persistentDataPath}/audio.mp3", AudioType.MPEG))
        {
            var op = www.SendWebRequest();
            while (!op.isDone) await Task.Yield();

            var clip = DownloadHandlerAudioClip.GetContent(www);

            audioSource.clip = clip;
            audioSource.Play();
        }
    }


    private void WriteToFile(Stream stream)
    {
        using (var fileStream = new FileStream($"{Application.persistentDataPath}/audio.mp3", FileMode.Create))
        {
            byte[] buffer = new byte[8 * 1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, bytesRead);
            }
        }
    }
}
