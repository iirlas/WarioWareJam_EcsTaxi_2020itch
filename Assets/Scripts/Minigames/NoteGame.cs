﻿using UnityEngine;

public class NoteGame : MonoBehaviour
{
   private int notesEntered = 0;
   private int[] notes = new int[4];
   private int Size => (int)Mathf.Sqrt(transform.childCount);

   // Start is called before the first frame update
   private void Start()
   {
      for (int ix = 0; ix < Size; ix++)
      {
         int val = Random.Range(0, Size) + (ix * Size);
         transform.GetChild(val).gameObject.SetActive(true);
         notes[ix] = val;
      }
   }

   // Update is called once per frame
   private void Update()
   {
      int key = -1;

      if (GameState.Instance.CurrentState == GameState.State.Playing)
      {
         if (Input.GetKeyDown(KeyCode.UpArrow))
         {
            key = 0;
            //0
         }
         else if (Input.GetKeyDown(KeyCode.DownArrow))
         {
            //1
            key = 1;
         }
         else if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
            //2
            key = 2;
         }
         else if (Input.GetKeyDown(KeyCode.RightArrow))
         {
            //3
            key = 3;
         }
      }

      if (key != -1 && (GameState.Instance.CurrentState == GameState.State.Playing))
      {
         if (key != (notes[notesEntered] - notesEntered * Size))
         {
            GameState.Instance.state.SetTrigger("Lose");
         }
         else
         {
            transform.GetChild(key + (notesEntered * Size)).GetComponent<SpriteRenderer>().color = Color.green;
            notesEntered++;

            if (notesEntered == Size)
            {
               GameState.Instance.state.SetTrigger("Win");
            }
         }
      }
   }
}