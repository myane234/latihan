using UnityEngine;
using System.Collections.Generic;

public class Judgement : MonoBehaviour
{

    public Transform[] judgementLines;
    public KeyCode[] laneKeys;
    public float hitWindow = 0.3f;
    public List<noted> notes;
    
    void Start()
    {
        // Setup default keys jika belum di-assign di Inspector
        if(laneKeys == null || laneKeys.Length == 0)
        {
            laneKeys = new KeyCode[4] { KeyCode.D, KeyCode.F, KeyCode.H, KeyCode.J };
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < laneKeys.Length; i++)
        {
            if(Input.GetKeyDown(laneKeys[i]))
            {
                CheckHit(i);
            }
        }
    }

    void CheckHit(int laneIndex)
    {
        // Validasi array
        if(judgementLines == null || judgementLines.Length == 0)
        {
            Debug.LogError("judgementLines belum di-assign!");
            return;
        }

        if(notes == null || notes.Count == 0)
        {
            Debug.LogWarning("Tidak ada note di list");
            return;
        }

        float judgeY = judgementLines[laneIndex].position.y;
        noted closestNote = null;
        float smallestDistance = float.MaxValue;

        foreach(noted note in notes)
        {
            if(note.laneIndex != laneIndex) continue;
            float distance = Mathf.Abs(note.transform.position.y - judgeY);
            Debug.Log($"Lane {laneIndex}: Note Y={note.transform.position.y}, Judge Y={judgeY}, Distance={distance}");
            
            if(distance < smallestDistance)
            {
                smallestDistance = distance;
                closestNote = note;
            }
        }

        if(closestNote != null && smallestDistance <= hitWindow)
        {
            Debug.Log("Hit sukses pada lane " + laneIndex);
            notes.Remove(closestNote);
            Destroy(closestNote.gameObject);
        } else
        {
            Debug.Log("Miss pada lane " + laneIndex + " (distance: " + smallestDistance + ")");
        }
    }
}