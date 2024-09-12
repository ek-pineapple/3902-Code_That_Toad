using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.ComponentModel.Design;

namespace Sprint0
{
    public class KeyboardController : IController
    {
        private Game1 myGame;
        private Dictionary<Keys, ICommand> keyboardControllerMappings;

        /* Constructor */
        public KeyboardController(Game1 game)
        {
            myGame = game;
            /* Creates a new dictionary to handle mapping of keyboard buttons to commands */
            keyboardControllerMappings = new Dictionary<Keys, ICommand>();
            //game commands
            AddCommand(Keys.D0, new ExitCommand(myGame));
            AddCommand(Keys.Q, new ExitCommand(myGame));
            //AddCommand(Keys.R, new ResetCommand(myGame));

            //sprite commands
            AddCommand(Keys.D1, new OneFrameFixedSpriteCommand(myGame));
            AddCommand(Keys.D2, new AnimatedFixedSpriteCommand(myGame));
            AddCommand(Keys.D3, new OneFrameMovingSpriteCommand(myGame));
            AddCommand(Keys.D4, new AnimatedMovingSpriteCommand(myGame));
            
            /*
            //block commands
            AddCommand(Keys.T, new PrevBlockCommand(myGame));
            AddCommand(Keys.Y, new NextBlockCommand(myGame));

            //item commands
            AddCommand(Keys.U, new PrevItemCommand(myGame));
            AddCommand(Keys.I, new NextItemCommand(myGame));

            //enemy commands
            AddCommand(Keys.O, new PrevEnemyCommand(myGame));
            AddCommand(Keys.P, new NextEnemyCommand(myGame));

            //player commands 
            AddCommand(Keys.W, new JumpCommand(myGame));
            AddCommand(Keys.A, new LeftCommand(myGame));
            AddCommand(Keys.S, new CrouchCommand(myGame));
            AddCommand(Keys.D, new RightCommand(myGame));
            AddCommand(Keys.Z, new AttackCommand(myGame));
            AddCommand(Keys.N, new AttackCommand(myGame));
            AddCommand(Keys.E, new DamageCommand(myGame));
            */
        }
        public void AddCommand(Keys key, ICommand command)
        {
            keyboardControllerMappings.Add(key, command);
        }
        public void Update()
        {
            KeyboardState newState = Keyboard.GetState();
            Keys[] keysToExecute = newState.GetPressedKeys();

            /* Obtain the corresponding command from the dictionary and call it */
            for (int i = 0; i < keysToExecute.Length; i++)
            {
                keyboardControllerMappings[keysToExecute[i]].Execute();
            }

        }

    }
}
