using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// This is the main type for your game.
/// </summary>
public class Game1Game : Game
{
    private MainMenu mainMenu;
    private SettingsMenu settingsMenu;
    private GamePlay gamePlay;
    private Music music;
    public UI ui;

    private bool interacted;

    public Sprite background;

    Cursor cursor;

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
        cursor = new Cursor();

        Globals.keyboard = new MyKeyboard();
        Globals.mouse = new MyMouseControl();

        Fonts.Init();
        Globals.defaultFont = Fonts.defaultFont24;

        music = new Music();
        mainMenu = new MainMenu();
        settingsMenu = new SettingsMenu();
        gamePlay = new GamePlay();
        Globals.reset = gamePlay.Reset;
        ui = new UI();

        background = new SpriteBuilder().WithPath("rect")
                                        .WithColor(Color.LightGoldenrodYellow)
                                        .WithDims(new Vector2(Coordinates.screenWidth, Coordinates.screenHeight))
                                        .WithTransitionable(false)
                                        .Build();
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
        if (TransitionManager.transState == TransitionState.OUT_REQUESTED)
        {
            TransitionManager.transState = TransitionState.BEGIN_OUT;
        }

        // TODO: Add your update logic here
        Globals.gameTime = gameTime;
        Globals.keyboard.Update();
        Globals.mouse.Update();

        if (!interacted && Globals.mouse.LeftClick())
        {
            Music.SetTrack();
            interacted = true;
        }

        switch (Globals.gameState)
        {
            case GameState.MAIN_MENU:
                mainMenu.Update();
                break;
            case GameState.SETTINGS:
                settingsMenu.Update();
                break;
            case GameState.GAME_PLAY:
                gamePlay.Update();
                break;
        }

        ui.Update();

        TransitionManager.Update();

        Globals.keyboard.UpdateOld();
        Globals.mouse.UpdateOld();

        cursor.Update();

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
        background.Draw();

        if (TransitionManager.transState != TransitionState.PAUSE)
        {
            switch (Globals.gameState)
            {
                case GameState.MAIN_MENU:
                    mainMenu.Draw();
                    break;
                case GameState.SETTINGS:
                    settingsMenu.Draw();
                    break;
                case GameState.GAME_PLAY:
                    gamePlay.Draw();
                    break;
            }
        }

        ui.Draw();

        cursor.Draw();

        Globals.spriteBatch.End();

        base.Draw(gameTime);
    }
}
