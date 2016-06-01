using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.scripts.story {

    public class StoryEntry {

        // Contains a single story entry, together with information about the
        // enemies linked to the story-snippet

        private string title;
        private int enemies;
        private int speed;
        private int health;
        private List<String> story_lines;
        private int current_line = 0;

        public StoryEntry() {
            title = "No title assigned";
            enemies = 0;
            speed = 1;
            health = 1;
            story_lines = new List<String>();
            current_line = -1;
        }

        public void SetTitle(string title) {
            this.title = title;
        }

        public void SetEnemies(int nbr_enemies) {
            this.enemies = nbr_enemies;
            Debug.Log("Enemy count: " + enemies);
        }

        public void SetSpeed(int speed) {
            this.speed = speed;
        }

        public void SetHealth(int health) {
            this.health = health;
        }

        public void AddStoryLine(string line) {
            story_lines.Add(line);
        }

        private string GetCurrentLine() {
            return story_lines[current_line];
        }

        public bool HasNextLine() {
            return (current_line < story_lines.Count - 1);
        }

        public string GetNextLine() {
            if (!HasNextLine()) {
                throw new ArgumentOutOfRangeException("No more lines! Index: " + current_line);
            }
            current_line += 1;
            return GetCurrentLine();
        }

        public int GetEnemyCount() {
            return enemies;
        }
    }
}
