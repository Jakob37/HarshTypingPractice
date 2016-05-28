using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.scripts.story {

    public class StoryEntry {

        // Contains a single story entry, together with information about the
        // enemies linked to the story-snippet

        private string title;
        private int enemies;
        private int speed;
        private int health;
        private List<String> story_lines;

        public StoryEntry() {
            title = "No title assigned";
            enemies = 0;
            speed = 1;
            health = 1;
            story_lines = new List<String>();
        }

        public void SetTitle(string title) {
            this.title = title;
        }

        public void SetEnemies(int nbr_enemies) {
            this.enemies = nbr_enemies;
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
    }
}
