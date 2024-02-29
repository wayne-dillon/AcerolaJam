using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

/// <summary>
/// This is the main type for your game.
/// </summary>
public class Game1Game : Game
{
    Gameplay gameplay;

    public Game1Game()
    {
        Globals.graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Globals.screenWidth = Coordinates.screenWidth = 1280;
        Globals.screenHeight = Coordinates.screenHeight = 720;

        Globals.graphics.PreferredBackBufferWidth = Globals.screenWidth;
        Globals.graphics.PreferredBackBufferHeight = Globals.screenHeight;

        Globals.graphics.ApplyChanges();

        base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
        Globals.content = Content;
        Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        Globals.keyboard = new MyKeyboard();
        Globals.mouse = new MyMouseControl();

        gameplay = new();
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here
        Globals.gameTime = gameTime;
        Globals.keyboard.Update();
        Globals.mouse.Update();

        gameplay.Update();

        Globals.keyboard.UpdateOld();
        Globals.mouse.UpdateOld();

        base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.LightGreen);

        Globals.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);

        // TODO: Add your drawing code here
        gameplay.Draw();

        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }
}
