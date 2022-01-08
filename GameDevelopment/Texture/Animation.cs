using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevelopment.Texture
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int fps;
        private bool repeat;
        private int counter;

        public Animation(int _fps = 15, bool _repeat = true)
        {
            frames = new List<AnimationFrame>();
            fps = _fps;
            repeat = _repeat;
        }

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public void ResetFrame()
        {
            CurrentFrame = frames[0];
            counter = 0;
            secondCounter = 0;
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }

            CurrentFrame = frames[0];

        }

        public void AddFramesFromTextureProperties(int widthOfFrame, int heightOfFrame, int rowOfSprites, int numberOfSprites, int startSprite = 1, int endSprite = int.MaxValue - 1)
        {
            for (int i = Math.Max(0, startSprite-1); i < Math.Min(numberOfSprites, endSprite); i++)
            {
                frames.Add(new AnimationFrame(new Rectangle(0 + i * widthOfFrame, (rowOfSprites-1)*heightOfFrame, widthOfFrame, heightOfFrame)));
            }

            CurrentFrame = frames[0];
        }

        private double secondCounter = 0;
        public void Update(GameTime gameTime)
        {
            if (!repeat)
            {
                if (counter + 1 == frames.Count)
                {
                    return;
                }
            }
            CurrentFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (secondCounter >= 1d / fps)
            {
                counter = (counter + 1) % frames.Count;
                secondCounter = 0;
            }
        }

    }
}
