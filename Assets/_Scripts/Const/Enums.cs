public enum GameObjectTag
{
    Car,
    Slot,
    Barrier,
    Entry,
    CarPark,
    NPC,
    PickupObject,
    Sand,
    SpeedHump,
}

public enum CarAnimName
{
    ShakingHittedHorizontal,
    ShakingHittedVertical,
    ShakingMove,
    Jump,
}

public enum SoundName
{
    CarCrashed,
    CarMove,
    CarWarning,
    CarDriff,
    ButtonClick,
    KeyPickup,
    LoseLevel,
    MysteryBoxPickup,
    PeopleCrashed,
    WinLevel,
    CoinPickUp,
    SpecialGiftHiddenBox,
    NormalGiftHiddenBox,
    AnimWin,
}

public enum NPCType
{
    Human,
    Car
}

public enum NPCAnimParamName
{
    fall,
}

public enum NPCHumanType
{
    Kid,
    OldWoman,
    Shipper
}

public enum MapSize
{
    // _6x12,
    _12x12,
    _18x12,
}

public enum PickupObjType
{
    MysteryBox,
    Key,
}

public enum TrailType
{
    None,
    FishBone,
    Star,
    Money,
    Bomb,
    Lightning,
    Shit
}

public enum RewardType
{
    Coins,
    TrafficLight,
    RoadMakings,
}

public enum CarColor
{
    None = -1,
    Green = 0,
    Orange = 1,
    Blue = 2,
    Purple = 3,
    Muscle_Purple = 4,
    Muscle_Orange = 5,
    Muscle_Blue = 6,
}

public enum GameMode
{
    NormalMode,
    HardMode,
    SortMode,
}

public enum ModeLevelButtonState
{
    Unlocked = 0,
    CanUnlock = 1,
    Lock = 2,
}