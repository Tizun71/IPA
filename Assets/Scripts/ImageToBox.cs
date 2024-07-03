using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageToBox : MonoBehaviour
{
    [SerializeField] int id;
    public Image image;
    public RandomQuestion randomQuestion;
    private string imageUrl;

    public string getImageUrl()
    {
        return imageUrl;
    }
    public void LoadImageFromFile(string relativePath)
    {
        relativePath = "Source/List/img/" + relativePath;
        // Combine the base path with the relative path
        string fullPath = Application.dataPath + '/' + relativePath;

        if (File.Exists(fullPath))
        {
            byte[] fileData = File.ReadAllBytes(fullPath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            image.sprite = newSprite;
        }
        else
        {
            Debug.LogError("File not found at " + fullPath);
        }
    }

    public void LoadImage()
    {
        if (id == randomQuestion.idFrameCorrect)
        {
            imageUrl = randomQuestion.imageAnswer;
            LoadImageFromFile(randomQuestion.imageAnswer);
        }
        else
        {
            imageUrl = randomQuestion.getRandomImage();
            LoadImageFromFile(randomQuestion.getRandomImage());
        }
    }

    private void Start()
    {
        LoadImage();
    }
}
