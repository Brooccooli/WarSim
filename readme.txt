Alvin Jangvik
A simple battle simulator with melee and ranged weapons.

Patterns:
- Observer pattern, Every movement is synced to the beat of the song through an event system where other classes subcribe to.
  The event is started in 'MusicPlayer.cs' and 'BotV1.cs's method Action is subscribed to the event.
- State machine, 'BotV1.cs' has a state machine with three enums( Attack, Walk and Wait).
- Abstract Factory, This is also in 'BotV1.cs'. The bots have a list of weapons that all derive from the 'IWeapon' interface
  and randomly chooses one on start. The bot script only refers to the weapons through the interface which makes it easier to 
  add new ones later on.