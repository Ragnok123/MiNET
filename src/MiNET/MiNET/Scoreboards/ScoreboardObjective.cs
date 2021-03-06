﻿using System;
using System.Collections.Generic;
using System.Text;
using MiNET.Entities;

namespace MiNET.Scoreboards
{
    public enum ScoreboardSort
    {
        Ascending = 0,
        Descending = 1
    }

    public class ScoreboardObjective
    {

        public String Name { get; set; }
        public ScoreboardDisplaySlot DisplaySlot { get; set; }
        public ScoreboardCriteria Criteria { get; set; }
        public String DisplayName { get; set; }
        public List<Score> Scores = new List<Score>();

        public byte Sort = (int)ScoreboardSort.Descending;

        public Score GetScore(String fakeplayer)
        {
            Score score = null;
            foreach(var scores in Scores)
            {
                if (scores.FakePlayer.Equals(fakeplayer))
                {
                    score = scores;
                }
            }
            return score;
        }

        public Score GetScore(Entity fakeplayer)
        {
            Score score = null;
            foreach (var scores in Scores)
            {
                if (scores.Entity.Equals(fakeplayer))
                {
                    score = scores;
                }
            }
            return score;
        }

        public void SetScore(Entity entity, int value)
        {
            var score = new Score(this, entity);
            score.SetScore(value);
            if (!Scores.Contains(score))
            {
                Scores.Add(score);
            } else
            {
                foreach (var scores in Scores)
                {
                    if(scores.Entity.Equals(entity))
                    {
                        Scores.Remove(scores);
                        Scores.Add(score);
                    }
                }
            }
        }

        public void SetScore(string entry, int value)
        {
            var score = new Score(this, entry);
            score.SetScore(value);
            if (!Scores.Contains(score))
            {
                Scores.Add(score);
            } else
            {
                foreach(var scores in Scores)
                {
                    if (scores.FakePlayer.Equals(entry))
                    {
                        Scores.Remove(scores);
                        Scores.Add(score);
                    }
                }
            }
        }

        public string CriteriaToString()
        {
            string s = "";
            switch (Criteria)
            {
                case ScoreboardCriteria.Dummy:
                    s = "dummy";
                    break;
            }
            return s;
        }

        public string SlotToString()
        {
            string slot = "";
            switch (DisplaySlot)
            {
                case ScoreboardDisplaySlot.Sidebar:
                    slot = "sidebar";
                    break;
                case ScoreboardDisplaySlot.List:
                    slot = "list";
                    break;
                case ScoreboardDisplaySlot.BelowName:
                    slot = "belowname";
                    break;
            }
            return slot;
        }

    }
}
