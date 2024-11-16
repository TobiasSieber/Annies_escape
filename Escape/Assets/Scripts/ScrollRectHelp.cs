using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectHelp : MonoBehaviour
{
    public ScrollRect scrollRect;

    //! Function to add a new line and scroll down by a certain distance
    public void AddNewLine()
    {
        //! Add the new line

        //! Scroll down by a certain distance
        StartCoroutine(ScrollDownByDistance());
    }

    IEnumerator ScrollDownByDistance()
    {
        //!Wait for the end of frame to ensure the content size has been updated
        yield return new WaitForEndOfFrame();

        // Calculate how much we need to scroll down
      

        //! Adjust the scroll position
        scrollRect.verticalNormalizedPosition -=0.002f;
    }
}