using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DL_Dialogue_DATA
{
    public List<Dialogue_SEGMENT> segments;
    private const string segmentIdentifierPattern = @"\{[ca]\}|\{w[ca]\s\d*\.?\d*\}";
    public bool hasDialogue => segments.Count > 0;
    
    public DL_Dialogue_DATA(string rawDialogue)
    {
        segments = RipSegments(rawDialogue);


    }

    public List<Dialogue_SEGMENT> RipSegments(string rawDialogue)
    {
        List<Dialogue_SEGMENT> segments = new List<Dialogue_SEGMENT>();
        
        MatchCollection matches = Regex.Matches(rawDialogue, segmentIdentifierPattern);

        int lastIndex = 0;
        Dialogue_SEGMENT segment = new Dialogue_SEGMENT();
        segment.dialogue = (matches.Count == 0 ? rawDialogue : rawDialogue.Substring(0, matches[0].Index));
        segment.startSignal = Dialogue_SEGMENT.StartSignal.NONE;
        segment.signalDelay = 0;
        segments.Add(segment);
        if (matches.Count == 0)
        {
            return segments;
        }
        else
        {
            lastIndex = matches[0].Index;
        }

        for (int i = 0; i < matches.Count; i++)
        {
            Match match = matches[i];
            segment = new Dialogue_SEGMENT();

            string signalMatch = match.Value; //{A}
            signalMatch = signalMatch.Substring(1,match.Length-2);
            string[] signalSplit = signalMatch.Split(' ');

            segment.startSignal =
                (Dialogue_SEGMENT.StartSignal)Enum.Parse(typeof(Dialogue_SEGMENT.StartSignal), signalSplit[0].ToUpper());
            if (signalSplit.Length > 1)
            {
                float.TryParse(signalSplit[1], out segment.signalDelay);
                
            }

            int nextIndex = i + 1 < matches.Count ? matches[i + 1].Index : rawDialogue.Length;
            segment.dialogue = rawDialogue.Substring(lastIndex+match.Length, nextIndex-(lastIndex+match.Length));
            lastIndex = nextIndex;
            segments.Add(segment);


        }

        return segments;

    }
    
    

    public struct Dialogue_SEGMENT
    {
        public string dialogue;
        public StartSignal startSignal;
        public float signalDelay;
        public enum StartSignal
        {
            
            NONE,
            C,
            A,
            WA,
            WC
        }
    }


}
