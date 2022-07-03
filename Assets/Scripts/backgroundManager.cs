using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEditor;
using Proyecto26;

public class backgroundManager : MonoBehaviour
{
    Canvas canvas;
    GameObject background;

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

    IEnumerator GetImage(string mediaUrl, int i, int j) {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError)) {
            print(request.error);
        } else {
            GameObject image = new GameObject((i + 1).ToString("00") + "-" + (j + 1).ToString("00"));

            RectTransform imageRectTransfrom = image.AddComponent<RectTransform>();
            imageRectTransfrom.SetParent(background.transform);
            imageRectTransfrom.localPosition = new Vector3(j * 400, -i * 400, 0);
            imageRectTransfrom.sizeDelta = new Vector2(400, 400);
            imageRectTransfrom.localScale = new Vector3(1, 1, 1);

            image.AddComponent<CanvasRenderer>();

            RawImage imageRawImage = image.AddComponent<RawImage>();
            imageRawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }

    IEnumerator GetImageMeta(int i, int j) {
        bool done = false;

        RestClient.Get<ImageMeta>("https://firebasestorage.googleapis.com/v0/b/taipan-354222.appspot.com/o/" + (i + 1).ToString("00") + "-" + (j + 1).ToString("00") + ".png").Then( response => {
            StartCoroutine(GetImage("https://firebasestorage.googleapis.com/v0/b/taipan-354222.appspot.com/o/" + (i + 1).ToString("00") + "-" + (j + 1).ToString("00") + ".png"+"?alt=media&token=" + response.downloadTokens, i, j));
        });

        if (!done)
        {
            yield return null;
        }
    }

    void Start()
    {
        canvas = GameObject.FindGameObjectsWithTag("Canvas")[0].GetComponent<Canvas>();

        background = new GameObject("Background");
        RectTransform backgroundRectTransform = background.AddComponent<RectTransform>();
        backgroundRectTransform.SetParent(canvas.transform);
        backgroundRectTransform.localPosition = new Vector3(0, 0, 0);

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                StartCoroutine(GetImageMeta(i, j));
            }
        }
    }
}
