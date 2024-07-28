using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class NoteLoader : MonoBehaviour
{
    [SerializeField] private NoteContainer notePrefab; // The UI element prefab to spawn
    [SerializeField] private Transform notesParent; // The parent transform for the spawned elements
    [SerializeField] private Image img;

    public List<GameObject> notes;


    private void OnEnable()
    {
       // notes = new List<GameObject>();
 
        foreach (GameObject note in notes)
        {
            Destroy(note);
        }
        notes.Clear();
        
        int amount = PlayerPrefs.GetInt("noteId", 0);

        if (amount == 0)
        {
            img.gameObject.SetActive(true);
        }
        else
        {
            img.gameObject.SetActive(false);
        }

        print (amount);
        SpawnNotes(amount);
    }

    private void SpawnNotes(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            NoteContainer newNote = Instantiate(notePrefab, notesParent.position, Quaternion.identity, notesParent.transform);
         
            newNote.transform.localPosition = notesParent.localPosition;

            newNote.namef.text = PlayerPrefs.GetString($"name{i}");
            newNote.rate.text = $"Finnish bathhouse / Rating {PlayerPrefs.GetInt($"stars{i}")}/10";
            newNote.adress.text = PlayerPrefs.GetString($"adress{i}");
            newNote.price.text = $"{PlayerPrefs.GetString($"price{i}")} $";
            newNote.desc.text = PlayerPrefs.GetString($"desc{i}");
         //   newNote.namef.text = PlayerPrefs.GetString($"name{i}");
            newNote.OnChangeStars(PlayerPrefs.GetInt($"stars{i}"));
            // Optionally, customize the newNote instance here
            notes.Add(newNote.gameObject);
        }
    }
}
