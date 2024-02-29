using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

public class Persistence
{
    public static Preferences preferences;

    private static string DocName() => "Content//XML//Preferences.xml";

    public static void LoadPreferences()
    {
        preferences = new();
        XElement xml = XDocument.Load(TitleContainer.OpenStream(DocName())).Element("preferences");

        preferences.musicVolume = Convert.ToInt32(xml.Element("musicVolume").Value);
        preferences.sfxVolume = Convert.ToInt32(xml.Element("sfxVolume").Value);
        preferences.fullScreen = Convert.ToBoolean(xml.Element("fullScreen").Value);
        preferences.resolution = Convert.ToInt32(xml.Element("resolution").Value);

        if (preferences.fullScreen) Globals.graphics.ToggleFullScreen();
    }

    public static void SavePreferences()
    {
        List<XElement> elements = new()
        {
            new("musicVolume", preferences.musicVolume),
            new("sfxVolume", preferences.sfxVolume),
            new("fullScreen", preferences.fullScreen),
            new("resolution", preferences.resolution),
        };

        XDocument xml = new(new XDeclaration("1.0", "utf-8", null), new XElement("preferences", elements));
        xml.Save(DocName());
    }
}