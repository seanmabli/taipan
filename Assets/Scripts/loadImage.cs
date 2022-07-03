using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor;
using Proyecto26;

[ExecuteInEditMode]
public class loadImage : MonoBehaviour
{
    public Texture2D texture;

    IEnumerator GetImage(string mediaUrl) {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError)) {
            print(request.error);
        } else {
            texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }

    [System.Serializable]
    public class ImageMeta
    {
        public string name;
        public string url;
        public int generation;
        public int metageneration;
        public string contentType;
        public string timeCreated;
        public string updated;
        public string storageClass;
        public int size;
        public string md5Hash;
        public string contentEncoding;
        public string crc32c;
        public string etag;
        public string downloadTokens;
    }

    void Start()
    {
        string imageName = "00-00";
        RestClient.Get<ImageMeta>("https://firebasestorage.googleapis.com/v0/b/taipan-354222.appspot.com/o/" + imageName + ".png").Then( response => {
            StartCoroutine(GetImage("https://firebasestorage.googleapis.com/v0/b/taipan-354222.appspot.com/o/" + imageName + ".png"+"?alt=media&token=" + response.downloadTokens));
            print(texture.width);
            print(texture.height);
            print(texture.GetPixel(0, 0));
        });
    }
}
