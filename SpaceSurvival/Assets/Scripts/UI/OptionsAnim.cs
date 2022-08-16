using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsAnim : MonoBehaviour
{
   public float increment;
   public float time;
   private SpriteRenderer spaceship;
   private SpriteRenderer background;
   private SpriteRenderer continueGame;
   private SpriteRenderer options;
   private SpriteRenderer newGame;
   private SpriteRenderer quit;
   private SpriteRenderer title;
   private SpriteRenderer pointer;

   private Color[] decorsColor;

   private int counter = 0;
 
   public void startBlur()
   {
      StartCoroutine(blurEffect());
   }

   IEnumerator blurEffect()
   {
      spaceship = GameObject.Find ("Spaceship").GetComponent<SpriteRenderer> ();
      background = GameObject.Find ("BackGround").GetComponent<SpriteRenderer> ();
      newGame = GameObject.Find ("NewGame").GetComponent<SpriteRenderer> ();
      continueGame = GameObject.Find ("Continue").GetComponent<SpriteRenderer> ();
      options = GameObject.Find ("Options").GetComponent<SpriteRenderer> ();
      quit = GameObject.Find ("Quit").GetComponent<SpriteRenderer> ();
      title = GameObject.Find ("GameTitle").GetComponent<SpriteRenderer> ();
      pointer = GameObject.Find("WhitePointer2").GetComponent<SpriteRenderer> ();


      Color tmp0 = spaceship.color;
      Color tmp1 = background.color;  
      Color tmp2 = newGame.color;
      Color tmp3 = continueGame.color; 
      Color tmp4 = options.color;
      Color tmp5 = quit.color; 
      Color tmp6 = title.color; 
      Color tmp7 = pointer.color;

      while(tmp0.a >= 0 || tmp1.a >= 0)
      {
         tmp0.a -= increment;
         tmp1.a -= increment;
         tmp2.a -= increment * 1.5f;
         tmp3.a -= increment * 1.5f;
         tmp4.a -= increment * 1.5f;
         tmp5.a -= increment * 1.5f;
         tmp6.a -= increment * 1.5f;
         tmp7.a -= increment * 1.5f;

         spaceship.color = tmp0;
         background.color = tmp1;
         newGame.color = tmp2;
         continueGame.color = tmp3;
         options.color = tmp4;
         quit.color = tmp5;
         title.color = tmp6;
         pointer.color = tmp7;

         yield return new WaitForSeconds(time);
      }
      GameObject.Find("Music").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Volume").GetComponent<SpriteRenderer>().enabled = true;
      GameObject.Find("Return").GetComponent<SpriteRenderer>().enabled = true;
      SliderControl.setVisible();
      StopCoroutine(blurEffect());
   }
}
