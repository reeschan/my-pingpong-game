using System.Collections.Generic;

public static class EffectHelper
{
  private static Dictionary<Effect, string> tagMap = new Dictionary<Effect, string>
  {
    { Effect.DestroyEnemy, "DestroyEnemy" },
    { Effect.WallCollision, "WallCollision" },
    { Effect.MenuSelect, "MenuSelect" },
    { Effect.GameStart, "GameStart" },
  };

  public static string GetEffectName(Effect effect)
  {
    return tagMap[effect];
  }
}