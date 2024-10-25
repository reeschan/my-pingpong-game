using System.Collections.Generic;
using UnityEngine;

public static class TagHelper
{
  private static Dictionary<Tag, string> tagMap = new Dictionary<Tag, string>
  {
    { Tag.Player, "Player" },
    { Tag.Enemy, "Enemy" },
    { Tag.Ball, "Ball" },
    { Tag.Wall, "Wall" },
    { Tag.GameOverZone, "GameOverZone" },
  };

  public static string GetTagName(Tag tag)
  {
    return tagMap[tag];
  }
}