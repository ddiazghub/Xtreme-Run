# Documentation

This is just a summary. See html/index.html for full code documentation.

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`class `[`AttemptsCounter`](#class_attempts_counter) | [Node](#class_node) for displaying the number of times the player has attempted a level.
`class `[`Avatar`](#class_avatar) | This class represents a customizable player avatar.
`class `[`Button`](#class_button) | 
`class `[`CanvasLayer`](#class_canvas_layer) | 
`class `[`ConfirmationDialog`](#class_confirmation_dialog) | 
`class `[`CreateProfileDialog`](#class_create_profile_dialog) | Popup for the creation of new profiles.
`class `[`EditProfileGUI`](#class_edit_profile_g_u_i) | GUI that allows the player to edit their profile data and customize their avatar.
`class `[`ExitGamePopup`](#class_exit_game_popup) | Confirms if the player wants to exit the game.
`class `[`FastFallAndRoll`](#class_fast_fall_and_roll) | Secondary action that allows the player to fall faster and dodge obstacles by rolling.
`class `[`GameAudio`](#class_game_audio) | [Node](#class_node) for playing audio globally in the game.
`class `[`GameHUD`](#class_game_h_u_d) | The hud that shows when the player is in a level.
`class `[`Glide`](#class_glide) | [Main](#class_main) action that allows the player to glide for some time.
`class `[`Jetpack`](#class_jetpack) | [Main](#class_main) action that allows the player to control to fly in a jetpack. This allows them to jump higher and have better control of their jump.
`class `[`Jump`](#class_jump) | [Main](#class_main) action that allows the player to jump.
`class `[`KinematicBody2D`](#class_kinematic_body2_d) | 
`class `[`Label`](#class_label) | 
`class `[`Level`](#class_level) | Base node for a game level scene.
`class `[`LevelComplete`](#class_level_complete) | Menu that will be shown when a level is completed.
`class `[`LevelPicker`](#class_level_picker) | [Node](#class_node) for picking a level on the main menu.
`class `[`Main`](#class_main) | The main [Node](#class_node) of the game. It is a state machine that executes a single scene at a time.
`class `[`MainAction`](#class_main_action) | Class that represents an action the player can perform as main action.
`class `[`MainActionPickup`](#class_main_action_pickup) | Pickup for player main action.
`class `[`MainMenu`](#class_main_menu) | The main menu of the game.
`class `[`MarginContainer`](#class_margin_container) | 
`class `[`Node`](#class_node) | 
`class `[`Node2D`](#class_node2_d) | 
`class `[`OnAirState`](#class_on_air_state) | Persisten state when the player is on air.
`class `[`OnGroundState`](#class_on_ground_state) | Persistent state when the player is grounded.
`class `[`Palette`](#class_palette) | Class that contains data related to colors.
`class `[`PaletteSwapEntry`](#class_palette_swap_entry) | Class that contains fields needed for [Palette](#class_palette) swapping.
`class `[`PaletteSwapShader`](#class_palette_swap_shader) | "Shader" for swapping colors in game textures.
`class `[`PauseMenu`](#class_pause_menu) | Menu that will be shown on pause.
`class `[`PersistentState`](#class_persistent_state) | Class that represents a player persistent state. Can be on air or on ground.
`class `[`Player`](#class_player) | The player node. It is a state machine that executes 3 states at each given time. The first state is a physical state (On ground, on air), while the other 2 are actions that the player can perform at a given time (Kind of like powers).
`class `[`PlayerSession`](#class_player_session) | Class that contains the the currently active profile.
`class `[`PlayerState`](#class_player_state) | Class that contains the base structure for a state that the player can have.
`class `[`PlayerStateFactory`](#class_player_state_factory) | This class generates states for the main class.
`class `[`PointsCounter`](#class_points_counter) | [Node](#class_node) for displaying a number of points.
`class `[`Profile`](#class_profile) | Class that represents and contains the data of a player's profile.
`class `[`ProfileGUI`](#class_profile_g_u_i) | Panel that displays the data of the currently active profile.
`class `[`ProfileSelect`](#class_profile_select) | Scene that displays a menu where profiles can be created, loaded and deleted.
`class `[`ProfileSelectEntry`](#class_profile_select_entry) | [Button](#class_button) that and allows the profile to be selected and displays a profile's data.
`class `[`SaveFileInfo`](#class_save_file_info) | Static class that contains some constants about save file structure.
`class `[`SceneFactory`](#class_scene_factory) | This class generates scenes for the main class.
`class `[`SecondaryAction`](#class_secondary_action) | Class that represents an action the player can perform as secondary action.
`class `[`SecondaryActionPickup`](#class_secondary_action_pickup) | Pickup for player secondary action.
`class `[`ShopGUI`](#class_shop_g_u_i) | The shop from which the player can buy items.
`class `[`SpawnedPlatform`](#class_spawned_platform) | Platforms that the player can spawn with the spawn platforms secondary action. They destroy themselves after half a second.
`class `[`SpawnPlatforms`](#class_spawn_platforms) | Secondary action that allows the player to spawn platforms while on air.
`class `[`SpinBox`](#class_spin_box) | 
`class `[`StaticBody2D`](#class_static_body2_d) | 
`class `[`SwitchGravity`](#class_switch_gravity) | Secondary action that allows the player to invert the direction of gravity.
`class `[`Teleport`](#class_teleport) | [Main](#class_main) action that allows the player to teleport a small distance above them.
`class `[`TeleportAndSwitchGravity`](#class_teleport_and_switch_gravity) | Secondary action that allows the player to teleport and invert the direction of gravity.
`class `[`TileSetMaker`](#class_tile_set_maker) | [Node](#class_node) for making tilesets from an image.

# class `AttemptsCounter` 

```
class AttemptsCounter
  : public Label
```  

[Node](#class_node) for displaying the number of times the player has attempted a level.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline override void `[`_Ready`](#class_attempts_counter_1a99139deffda97733aace251332587621)`()` | 
`public inline void `[`Set`](#class_attempts_counter_1a4cdb5bb63a2ef619112652644b397be7)`(int attempts)` | Sets a new number of attempts.

## Members

#### `public inline override void `[`_Ready`](#class_attempts_counter_1a99139deffda97733aace251332587621)`()` 

#### `public inline void `[`Set`](#class_attempts_counter_1a4cdb5bb63a2ef619112652644b397be7)`(int attempts)` 

Sets a new number of attempts.

#### Parameters
* `attempts` New number of attempts.

# class `Avatar` 

This class represents a customizable player avatar.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} bool `[`Male`](#class_avatar_1ac867c076ca88765a4601c440687a42c9) | The avatar's Gender. True if male, false if female.
`{property} int `[`SkinColor`](#class_avatar_1a267cad98d66d8c4cb7008c967f9dd176) | Id of the avatar's skin color.
`{property} int `[`TopColor`](#class_avatar_1ab97d2d7a4d5aaf7c767eeb4852ad1c49) | Id of the avatar's bottom color.
`{property} int `[`BottomColor`](#class_avatar_1af14516033bd4b5bcb567506d3e480dca) | Id of the avatar's top color.
`public inline  `[`Avatar`](#class_avatar_1a05399ad1121eec3010368f54ca8ad9fc)`(bool male,int skinColor,int topColor,int bottomColor)` | Creates a new avatar from the supplied data.
`public inline int `[`GetColor`](#class_avatar_1afe361a71356eeb5a67ce7974bd8881d7)`(string key)` | Gets one of the avatar's colors from a given string.
`public inline void `[`SetColor`](#class_avatar_1a27818736da2c886b8a891d3009b43752)`(string key,int color)` | Sets one of the avatar's colors from a given string.
`public inline Texture `[`ToTexture`](#class_avatar_1a556317afdd76c7884ae0197014a7459a)`()` | Performs a palette swap on the default avatar, swapping the default colors for the colors specified in each property. Converts the avatar into an image texture.
`public inline `[`Avatar`](#class_avatar)` `[`Clone`](#class_avatar_1a6a7e03a2e5274437e9d3d819c830f372)`()` | Clones the avatar.

## Members

#### `{property} bool `[`Male`](#class_avatar_1ac867c076ca88765a4601c440687a42c9) 

The avatar's Gender. True if male, false if female.

#### `{property} int `[`SkinColor`](#class_avatar_1a267cad98d66d8c4cb7008c967f9dd176) 

Id of the avatar's skin color.

#### `{property} int `[`TopColor`](#class_avatar_1ab97d2d7a4d5aaf7c767eeb4852ad1c49) 

Id of the avatar's bottom color.

#### `{property} int `[`BottomColor`](#class_avatar_1af14516033bd4b5bcb567506d3e480dca) 

Id of the avatar's top color.

#### `public inline  `[`Avatar`](#class_avatar_1a05399ad1121eec3010368f54ca8ad9fc)`(bool male,int skinColor,int topColor,int bottomColor)` 

Creates a new avatar from the supplied data.

#### Parameters
* `male` The avatar's Gender. True if male, false if female.

* `skinColor` Id of the avatar's skin color.

* `topColor` Id of the avatar's bottom color.

* `bottomColor` Default avatar for non-created profiles.

#### `public inline int `[`GetColor`](#class_avatar_1afe361a71356eeb5a67ce7974bd8881d7)`(string key)` 

Gets one of the avatar's colors from a given string.

#### Parameters
* `key` Can be Skin, Top or Bottom.

#### Returns
The color corresponding to the string.

#### `public inline void `[`SetColor`](#class_avatar_1a27818736da2c886b8a891d3009b43752)`(string key,int color)` 

Sets one of the avatar's colors from a given string.

#### Parameters
* `key` Can be Skin, Top or Bottom.

#### `public inline Texture `[`ToTexture`](#class_avatar_1a556317afdd76c7884ae0197014a7459a)`()` 

Performs a palette swap on the default avatar, swapping the default colors for the colors specified in each property. Converts the avatar into an image texture.

#### Returns
The avatar as an image texture.

#### `public inline `[`Avatar`](#class_avatar)` `[`Clone`](#class_avatar_1a6a7e03a2e5274437e9d3d819c830f372)`()` 

Clones the avatar.

#### Returns
A copy of the avatar.

# class `Button` 

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `CanvasLayer` 

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `ConfirmationDialog` 

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `CreateProfileDialog` 

```
class CreateProfileDialog
  : public ConfirmationDialog
```  

Popup for the creation of new profiles.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public delegate void `[`CreationFailed`](#class_create_profile_dialog_1aaee4a09777e0914a99edf9637301e617)`()` | Emitted if the profiled wasn't created succesfully.
`public inline override void `[`_Ready`](#class_create_profile_dialog_1a107ddac39ac301541def8b5b8cea85b9)`()` | 
`public inline void `[`OnCreateProfileDialogConfirmed`](#class_create_profile_dialog_1a49bc2876b4cb7a3ae6d76b836b406849)`()` | 
`public inline void `[`OnCreateProfileDialogAboutToShow`](#class_create_profile_dialog_1a804665f81f54d577fd173054c5ec87bb)`()` | 

## Members

#### `public delegate void `[`CreationFailed`](#class_create_profile_dialog_1aaee4a09777e0914a99edf9637301e617)`()` 

Emitted if the profiled wasn't created succesfully.

#### `public inline override void `[`_Ready`](#class_create_profile_dialog_1a107ddac39ac301541def8b5b8cea85b9)`()` 

#### `public inline void `[`OnCreateProfileDialogConfirmed`](#class_create_profile_dialog_1a49bc2876b4cb7a3ae6d76b836b406849)`()` 

#### `public inline void `[`OnCreateProfileDialogAboutToShow`](#class_create_profile_dialog_1a804665f81f54d577fd173054c5ec87bb)`()` 

# class `EditProfileGUI` 

```
class EditProfileGUI
  : public NinePatchRect
```  

GUI that allows the player to edit their profile data and customize their avatar.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public delegate void `[`ProfileChanged`](#class_edit_profile_g_u_i_1af257feffa6ba5f4681f5d315059f4cd2)`()` | Emitted if the user profile's data was modified.
`public inline override void `[`_Ready`](#class_edit_profile_g_u_i_1a2708ce86420d102c0f76583100611d32)`()` | 
`public inline override void `[`_Process`](#class_edit_profile_g_u_i_1a1473f46ade313ff644af04f27f49555e)`(float delta)` | 
`public inline bool `[`UnsavedChanges`](#class_edit_profile_g_u_i_1a54726f386c9921c011c5defc5341c644)`()` | Checks if the player has edited their avatar and the changes haven't been saved.
`public inline void `[`UpdateAvatar`](#class_edit_profile_g_u_i_1a0c57b976943d328fb48bf697c18d386a)`()` | Updates the data of the avatar being edited depending on user input. Displays the new avatar.
`public inline void `[`OnColorPressed`](#class_edit_profile_g_u_i_1aa1f1583bb34d1d218900d1904098d98b)`()` | 
`public inline void `[`OnGenderItemSelected`](#class_edit_profile_g_u_i_1abe027814d99058c40f06aa61ecbef381)`(int index)` | 
`public inline void `[`OnCancelPressed`](#class_edit_profile_g_u_i_1ae62a6598f2588467732b64a847b40bde)`()` | 
`public inline void `[`OnSavePressed`](#class_edit_profile_g_u_i_1a4b00cca39e0201eff072264a55291a35)`()` | 

## Members

#### `public delegate void `[`ProfileChanged`](#class_edit_profile_g_u_i_1af257feffa6ba5f4681f5d315059f4cd2)`()` 

Emitted if the user profile's data was modified.

#### `public inline override void `[`_Ready`](#class_edit_profile_g_u_i_1a2708ce86420d102c0f76583100611d32)`()` 

#### `public inline override void `[`_Process`](#class_edit_profile_g_u_i_1a1473f46ade313ff644af04f27f49555e)`(float delta)` 

#### `public inline bool `[`UnsavedChanges`](#class_edit_profile_g_u_i_1a54726f386c9921c011c5defc5341c644)`()` 

Checks if the player has edited their avatar and the changes haven't been saved.

#### Returns
True if the changes are unsaved, false otherwise.

#### `public inline void `[`UpdateAvatar`](#class_edit_profile_g_u_i_1a0c57b976943d328fb48bf697c18d386a)`()` 

Updates the data of the avatar being edited depending on user input. Displays the new avatar.

#### `public inline void `[`OnColorPressed`](#class_edit_profile_g_u_i_1aa1f1583bb34d1d218900d1904098d98b)`()` 

#### `public inline void `[`OnGenderItemSelected`](#class_edit_profile_g_u_i_1abe027814d99058c40f06aa61ecbef381)`(int index)` 

#### `public inline void `[`OnCancelPressed`](#class_edit_profile_g_u_i_1ae62a6598f2588467732b64a847b40bde)`()` 

#### `public inline void `[`OnSavePressed`](#class_edit_profile_g_u_i_1a4b00cca39e0201eff072264a55291a35)`()` 

# class `ExitGamePopup` 

```
class ExitGamePopup
  : public ConfirmationDialog
```  

Confirms if the player wants to exit the game.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline override void `[`_Ready`](#class_exit_game_popup_1a18cc2ab5c871235f3049d1f8f036606d)`()` | 
`public inline void `[`OnExitGamePopupConfirmed`](#class_exit_game_popup_1ae3860bc0823259a74c9a13bcecea801a)`()` | 

## Members

#### `public inline override void `[`_Ready`](#class_exit_game_popup_1a18cc2ab5c871235f3049d1f8f036606d)`()` 

#### `public inline void `[`OnExitGamePopupConfirmed`](#class_exit_game_popup_1ae3860bc0823259a74c9a13bcecea801a)`()` 

# class `FastFallAndRoll` 

```
class FastFallAndRoll
  : public SecondaryAction
```  

Secondary action that allows the player to fall faster and dodge obstacles by rolling.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline virtual override void `[`_ActionOnGround`](#class_fast_fall_and_roll_1a677376011ccf63f6cf5408f52275d48a)`()` | The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.
`public inline virtual override void `[`_ActionOnAir`](#class_fast_fall_and_roll_1a63c245a9215306232f86d96c50b9fb20)`()` | The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.
`public inline virtual override void `[`OnSecondaryActionTimerTimeout`](#class_fast_fall_and_roll_1a4ee1aec7ed7f5bfe9ec6bf798a16023d)`()` | 

## Members

#### `public inline virtual override void `[`_ActionOnGround`](#class_fast_fall_and_roll_1a677376011ccf63f6cf5408f52275d48a)`()` 

The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.

#### `public inline virtual override void `[`_ActionOnAir`](#class_fast_fall_and_roll_1a63c245a9215306232f86d96c50b9fb20)`()` 

The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.

#### `public inline virtual override void `[`OnSecondaryActionTimerTimeout`](#class_fast_fall_and_roll_1a4ee1aec7ed7f5bfe9ec6bf798a16023d)`()` 

# class `GameAudio` 

```
class GameAudio
  : public Node2D
```  

[Node](#class_node) for playing audio globally in the game.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public AudioStream `[`MenuMusic`](#class_game_audio_1a20ac51641bd1520e7e2f98256ced7da4) | Music to play on menus.
`public AudioStream `[`Level1Music`](#class_game_audio_1acb552d42a8760720c6f3fe39dce1bee1) | [Level](#class_level) 1 music.
`public AudioStream `[`Level2Music`](#class_game_audio_1a13fe2789ea3a9ebdadfb82447958be08) | [Level](#class_level) 2 music.
`public AudioStream `[`Level3Music`](#class_game_audio_1ac66409802e2533dafa25f107a458c8d5) | [Level](#class_level) 3 music.
`public AudioStream `[`AcceptSFX`](#class_game_audio_1a45bab24c53b73c4aca26066bfd55292d) | Audio effect to play when clicking an accept button.
`public AudioStream `[`CancelSFX`](#class_game_audio_1a3d83cb6ed0d90390c4c52773c849e4cc) | Audio effect to play when clicking an cancel/back button.
`public AudioStream `[`DeathSFX`](#class_game_audio_1a1b3ec5e7aebb587bc735b76026c4f098) | Audio effect to play when the player dies.
`public AudioStream `[`JumpSFX`](#class_game_audio_1ab05094f6a17b0e8355112a6024cae50c) | Audio effect to play when the player jumps.
`public AudioStream `[`PickupSFX`](#class_game_audio_1ab8e43f74aa38d82514d3025e0833033d) | Audio effect to play when player comes in contact with an action pickup.
`public inline override void `[`_Ready`](#class_game_audio_1af4311a2ca53fd2ba2e1eabd38e10c6f0)`()` | 
`public inline void `[`SetMusic`](#class_game_audio_1ac494431eace52893c1a35c662e74dee2)`(`[`GameScenes`](#_game_scenes_8cs_1a0687e907db3af3681f90377d69f32090)` scene)` | Sets a new music track, depending on the scene.
`public inline void `[`PlayAccept`](#class_game_audio_1aec65bb06501eeacbc6ae63f764ed2d02)`()` | Plays the accept audio effect.
`public inline void `[`PlayCancel`](#class_game_audio_1ae5d1e42bdbddd5e804a9201ded74f7d8)`()` | Plays the cancel audio effect.
`public inline void `[`PlayDeath`](#class_game_audio_1aeaebd5d3ac12494cb693a2e7ea233246)`()` | Plays the death sound effect.
`public inline void `[`PlayPickup`](#class_game_audio_1a5bb181af6c57c5794a624890e967782c)`()` | Plays the pickup sound effect.
`public inline void `[`PlayJump`](#class_game_audio_1afd92bfe560ae4047f75e9165d0a935da)`()` | Plays the jump sound effect.
`public inline void `[`OnMusicFinished`](#class_game_audio_1a6df13bded33b7c1ae4efa1d2d5b0eef2)`()` | 
`public inline void `[`OnSfxFinished`](#class_game_audio_1addcf597b4df4aba37d5bee5be86a476e)`()` | 

## Members

#### `public AudioStream `[`MenuMusic`](#class_game_audio_1a20ac51641bd1520e7e2f98256ced7da4) 

Music to play on menus.

#### `public AudioStream `[`Level1Music`](#class_game_audio_1acb552d42a8760720c6f3fe39dce1bee1) 

[Level](#class_level) 1 music.

#### `public AudioStream `[`Level2Music`](#class_game_audio_1a13fe2789ea3a9ebdadfb82447958be08) 

[Level](#class_level) 2 music.

#### `public AudioStream `[`Level3Music`](#class_game_audio_1ac66409802e2533dafa25f107a458c8d5) 

[Level](#class_level) 3 music.

#### `public AudioStream `[`AcceptSFX`](#class_game_audio_1a45bab24c53b73c4aca26066bfd55292d) 

Audio effect to play when clicking an accept button.

#### `public AudioStream `[`CancelSFX`](#class_game_audio_1a3d83cb6ed0d90390c4c52773c849e4cc) 

Audio effect to play when clicking an cancel/back button.

#### `public AudioStream `[`DeathSFX`](#class_game_audio_1a1b3ec5e7aebb587bc735b76026c4f098) 

Audio effect to play when the player dies.

#### `public AudioStream `[`JumpSFX`](#class_game_audio_1ab05094f6a17b0e8355112a6024cae50c) 

Audio effect to play when the player jumps.

#### `public AudioStream `[`PickupSFX`](#class_game_audio_1ab8e43f74aa38d82514d3025e0833033d) 

Audio effect to play when player comes in contact with an action pickup.

#### `public inline override void `[`_Ready`](#class_game_audio_1af4311a2ca53fd2ba2e1eabd38e10c6f0)`()` 

#### `public inline void `[`SetMusic`](#class_game_audio_1ac494431eace52893c1a35c662e74dee2)`(`[`GameScenes`](#_game_scenes_8cs_1a0687e907db3af3681f90377d69f32090)` scene)` 

Sets a new music track, depending on the scene.

#### Parameters
* `scene` The new scene executed by the main scene.

#### `public inline void `[`PlayAccept`](#class_game_audio_1aec65bb06501eeacbc6ae63f764ed2d02)`()` 

Plays the accept audio effect.

#### `public inline void `[`PlayCancel`](#class_game_audio_1ae5d1e42bdbddd5e804a9201ded74f7d8)`()` 

Plays the cancel audio effect.

#### `public inline void `[`PlayDeath`](#class_game_audio_1aeaebd5d3ac12494cb693a2e7ea233246)`()` 

Plays the death sound effect.

#### `public inline void `[`PlayPickup`](#class_game_audio_1a5bb181af6c57c5794a624890e967782c)`()` 

Plays the pickup sound effect.

#### `public inline void `[`PlayJump`](#class_game_audio_1afd92bfe560ae4047f75e9165d0a935da)`()` 

Plays the jump sound effect.

#### `public inline void `[`OnMusicFinished`](#class_game_audio_1a6df13bded33b7c1ae4efa1d2d5b0eef2)`()` 

#### `public inline void `[`OnSfxFinished`](#class_game_audio_1addcf597b4df4aba37d5bee5be86a476e)`()` 

# class `GameHUD` 

```
class GameHUD
  : public CanvasLayer
```  

The hud that shows when the player is in a level.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public delegate void `[`PausePressed`](#class_game_h_u_d_1ac09e85b7ce65957efbd8bbdfdd4b8a26)`()` | Signal emitted when the pause button is pressed.
`public delegate void `[`PauseMouseEntered`](#class_game_h_u_d_1afcc3b8e708e40ba3ff8e8307c8d80ae5)`()` | Signal emitted when the mouse enters the pause button area.
`public delegate void `[`PauseMouseExited`](#class_game_h_u_d_1a90646dbfe93e9d42dc67db2f4b8ee7a8)`()` | Signal emitted when the mouse exits the pause button area.
`public inline override void `[`_Ready`](#class_game_h_u_d_1ae27ae16bd96db64b23a7df4d83f08026)`()` | 
`public inline void `[`SetPoints`](#class_game_h_u_d_1a511dd4c57dc75287bfa056bdbba46d95)`(int points)` | Sets the number of points to display in the points counter.
`public inline void `[`SetProgress`](#class_game_h_u_d_1ad76c722e11f1eae273e8096f843646fb)`(double percent)` | Sets the progress to display in the level progress bar.
`public inline void `[`SetAttempts`](#class_game_h_u_d_1a1b64a3c74071717408c1c809a4a6804a)`(int number)` | Sets the number of attempts to display on the attempts counter.
`public inline void `[`SetActions`](#class_game_h_u_d_1aca0c2fc700f10a3aed6b1f65c13bfadd)`(`[`PlayerMainAction`](#_player_main_action_8cs_1adbd1afd3268279088266e6463135cac9)` main,`[`PlayerSecondaryAction`](#_player_secondary_action_8cs_1a92b46946fafc071a922f285614a74b88)` secondary)` | Sets the player actions to display on the hud.
`public inline void `[`OnPausePressed`](#class_game_h_u_d_1a317071a9133c94c6efcbe8c81ee17516)`()` | 
`public inline void `[`OnPauseMouseEntered`](#class_game_h_u_d_1a0d307f074a3fc08d2d46626445ca8041)`()` | 
`public inline void `[`OnPauseMouseExited`](#class_game_h_u_d_1a182e186269a8e128619312c89dca36fd)`()` | 

## Members

#### `public delegate void `[`PausePressed`](#class_game_h_u_d_1ac09e85b7ce65957efbd8bbdfdd4b8a26)`()` 

Signal emitted when the pause button is pressed.

#### `public delegate void `[`PauseMouseEntered`](#class_game_h_u_d_1afcc3b8e708e40ba3ff8e8307c8d80ae5)`()` 

Signal emitted when the mouse enters the pause button area.

#### `public delegate void `[`PauseMouseExited`](#class_game_h_u_d_1a90646dbfe93e9d42dc67db2f4b8ee7a8)`()` 

Signal emitted when the mouse exits the pause button area.

#### `public inline override void `[`_Ready`](#class_game_h_u_d_1ae27ae16bd96db64b23a7df4d83f08026)`()` 

#### `public inline void `[`SetPoints`](#class_game_h_u_d_1a511dd4c57dc75287bfa056bdbba46d95)`(int points)` 

Sets the number of points to display in the points counter.

#### Parameters
* `points` The new number of points to display.

#### `public inline void `[`SetProgress`](#class_game_h_u_d_1ad76c722e11f1eae273e8096f843646fb)`(double percent)` 

Sets the progress to display in the level progress bar.

#### Parameters
* `percent` The player's new progress.

#### `public inline void `[`SetAttempts`](#class_game_h_u_d_1a1b64a3c74071717408c1c809a4a6804a)`(int number)` 

Sets the number of attempts to display on the attempts counter.

#### Parameters
* `number` The player's new number of attempts.

#### `public inline void `[`SetActions`](#class_game_h_u_d_1aca0c2fc700f10a3aed6b1f65c13bfadd)`(`[`PlayerMainAction`](#_player_main_action_8cs_1adbd1afd3268279088266e6463135cac9)` main,`[`PlayerSecondaryAction`](#_player_secondary_action_8cs_1a92b46946fafc071a922f285614a74b88)` secondary)` 

Sets the player actions to display on the hud.

#### Parameters
* `main` The main action the player currently has.

* `secondary` The secondary action the player currently has.

#### `public inline void `[`OnPausePressed`](#class_game_h_u_d_1a317071a9133c94c6efcbe8c81ee17516)`()` 

#### `public inline void `[`OnPauseMouseEntered`](#class_game_h_u_d_1a0d307f074a3fc08d2d46626445ca8041)`()` 

#### `public inline void `[`OnPauseMouseExited`](#class_game_h_u_d_1a182e186269a8e128619312c89dca36fd)`()` 

# class `Glide` 

```
class Glide
  : public MainAction
```  

[Main](#class_main) action that allows the player to glide for some time.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline virtual override void `[`_Init`](#class_glide_1a12360a9f1b649403f8e018ba7347ed76)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_StatePhysicsProcess`](#class_glide_1aa56164cb76d7401b99ab8f2ba5dcc397)`(float delta)` | The physics process that will be called each frame for the state.
`public inline virtual override void `[`_ActionOnGround`](#class_glide_1a807e0e90013a5c0f6b509a565efeff27)`()` | 
`public inline virtual override void `[`_ActionOnAir`](#class_glide_1a701b0bc067e81b3d3fca24aaf4293088)`()` | 
`public inline virtual override void `[`_ActionReleased`](#class_glide_1a2353d380d6897004724d34c31838f798)`()` | 
`public inline virtual override void `[`_ActionProcess`](#class_glide_1a14d5f2b568b6a3573166ffe8384a5be5)`(float delta)` | The process that will be executed each frame while the action is being performed.
`public inline virtual override void `[`OnMainActionTimerTimeout`](#class_glide_1a721ca45c8d7ddfeb0b25f726540c770d)`()` | 
`public inline virtual override void `[`OnMainActionObjectCollisionCheckAreaEntered`](#class_glide_1ac7d01853752f27addde9526b665b3d62)`(Area2D area)` | 

## Members

#### `public inline virtual override void `[`_Init`](#class_glide_1a12360a9f1b649403f8e018ba7347ed76)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_StatePhysicsProcess`](#class_glide_1aa56164cb76d7401b99ab8f2ba5dcc397)`(float delta)` 

The physics process that will be called each frame for the state.

#### Parameters
* `delta` Time since the last frame.

#### `public inline virtual override void `[`_ActionOnGround`](#class_glide_1a807e0e90013a5c0f6b509a565efeff27)`()` 

#### `public inline virtual override void `[`_ActionOnAir`](#class_glide_1a701b0bc067e81b3d3fca24aaf4293088)`()` 

#### `public inline virtual override void `[`_ActionReleased`](#class_glide_1a2353d380d6897004724d34c31838f798)`()` 

#### `public inline virtual override void `[`_ActionProcess`](#class_glide_1a14d5f2b568b6a3573166ffe8384a5be5)`(float delta)` 

The process that will be executed each frame while the action is being performed.

#### Parameters
* `delta` Time since last frame.

#### `public inline virtual override void `[`OnMainActionTimerTimeout`](#class_glide_1a721ca45c8d7ddfeb0b25f726540c770d)`()` 

#### `public inline virtual override void `[`OnMainActionObjectCollisionCheckAreaEntered`](#class_glide_1ac7d01853752f27addde9526b665b3d62)`(Area2D area)` 

# class `Jetpack` 

```
class Jetpack
  : public MainAction
```  

[Main](#class_main) action that allows the player to control to fly in a jetpack. This allows them to jump higher and have better control of their jump.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline virtual override void `[`_Init`](#class_jetpack_1a71bdeb3eeccdbca43f304ae31b5c206b)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_ActionReleased`](#class_jetpack_1a66a6e0bb7ff231a6e843f9f67a4d7642)`()` | 
`public inline virtual override void `[`_ActionProcess`](#class_jetpack_1a2f099459f3cdeef59c2a73a86edb334c)`(float delta)` | The process that will be executed each frame while the action is being performed.
`public inline virtual override void `[`OnMainActionObjectCollisionCheckAreaEntered`](#class_jetpack_1a1a4d6a6693480ef6ed70627399da3e25)`(Area2D area)` | 
`public inline virtual override void `[`OnMainActionTimerTimeout`](#class_jetpack_1ae5d732914ec97154f9f14d12e96730d3)`()` | 

## Members

#### `public inline virtual override void `[`_Init`](#class_jetpack_1a71bdeb3eeccdbca43f304ae31b5c206b)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_ActionReleased`](#class_jetpack_1a66a6e0bb7ff231a6e843f9f67a4d7642)`()` 

#### `public inline virtual override void `[`_ActionProcess`](#class_jetpack_1a2f099459f3cdeef59c2a73a86edb334c)`(float delta)` 

The process that will be executed each frame while the action is being performed.

#### Parameters
* `delta` Time since last frame.

#### `public inline virtual override void `[`OnMainActionObjectCollisionCheckAreaEntered`](#class_jetpack_1a1a4d6a6693480ef6ed70627399da3e25)`(Area2D area)` 

#### `public inline virtual override void `[`OnMainActionTimerTimeout`](#class_jetpack_1ae5d732914ec97154f9f14d12e96730d3)`()` 

# class `Jump` 

```
class Jump
  : public MainAction
```  

[Main](#class_main) action that allows the player to jump.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline virtual override void `[`_Init`](#class_jump_1a1c628cf6144679785b27250e8b496234)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_ActionProcess`](#class_jump_1a44577960ec4edd622c95a6f5b76dfacb)`(float delta)` | The process that will be executed each frame while the action is being performed.

## Members

#### `public inline virtual override void `[`_Init`](#class_jump_1a1c628cf6144679785b27250e8b496234)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_ActionProcess`](#class_jump_1a44577960ec4edd622c95a6f5b76dfacb)`(float delta)` 

The process that will be executed each frame while the action is being performed.

#### Parameters
* `delta` Time since last frame.

# class `KinematicBody2D` 

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `Label` 

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `Level` 

```
class Level
  : public Node2D
```  

Base node for a game level scene.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public int `[`LevelNumber`](#class_level_1a08e6603e6ab77dc1ca2d58c2ed8221a0) | The level's number.
`public List< Vector2 > `[`positions`](#class_level_1a68bdb4fa6a0a7d317daaaf44c06599f2) | 
`public delegate void `[`PlayerDead`](#class_level_1a963f02696507398ac850dcaee43ff321)`()` | Emitted when the player dies.
`public delegate void `[`PlayerPerformedMainAction`](#class_level_1a9cb1b65bbf3e9ff796adf998f7b748d3)`()` | Emitted when the player performs a main action.
`public delegate void `[`PlayerPickup`](#class_level_1afec3b7fef9b7c0c9e590b2ca2a47245c)`()` | Emitted when the player pickups an action.
`public inline override void `[`_Ready`](#class_level_1a9b982efc154865a30a5c589d72f0a900)`()` | 
`public inline override void `[`_Process`](#class_level_1adf87a658b5a922295a3bbab87f5820b5)`(float delta)` | 
`public inline override void `[`_Draw`](#class_level_1ab147d68f7a06156f6a0cd595bf58f75d)`()` | 
`public inline void `[`Restart`](#class_level_1a20b2f496054effcd20120b8cb37c14dc)`()` | Restarts the level, resets the player's position and the hud.
`public inline void `[`UpdateProgress`](#class_level_1a209b18b3eef463ac8dc4caf19d869f11)`()` | Calculates the progress that the player currently has on the level.
`public inline int `[`GetPoints`](#class_level_1a866f3830aa6da6db116ecd9204b1b7a6)`()` | Gets the number of points that the player has earned on the current run.
`public inline void `[`MoveViewPort`](#class_level_1a37da9eda7a3cd74e5a8c4d5e92e83b18)`()` | Moves the camera and the background to follow the player.
`public inline void `[`Pause`](#class_level_1ae81c01f79951151a432bbdbf1cdb3dd8)`()` | Pauses the game.
`public inline void `[`SaveData`](#class_level_1a4bb15a932ab317c90d5de0623b9f8d88)`()` | Saves the player's progress.
`public inline void `[`OnPlayerDead`](#class_level_1a6807430e5f1f262aca25e7bc40fbac90)`()` | 
`public inline void `[`OnPlayerPickup`](#class_level_1a7c2ac37de0d423fa6c95bbce4b0eebf5)`()` | 
`public inline void `[`OnPlayerPerformedMainAction`](#class_level_1a89dbf1585c31caa958aa431823f2f4f7)`()` | 
`public inline void `[`OnHudPausePressed`](#class_level_1a08ef0cf0dd18af04729d4d01deaeea66)`()` | 
`public inline void `[`OnHudPauseMouseEntered`](#class_level_1a2cd7ebf61994f7cc65f672f8cc0b20ae)`()` | 
`public inline void `[`OnHudPauseMouseExited`](#class_level_1a462cabf043b2870fda20d5a7c25e6d40)`()` | 
`public inline void `[`OnPauseMenuRestartPressed`](#class_level_1a4ecafdfb8a186ec3bffe2cae913616f8)`()` | 
`public inline void `[`OnEndPositionBodyEntered`](#class_level_1aa0e6bfa6d80ec968a1995f395e016a0b)`(`[`Node`](#class_node)` body)` | 

## Members

#### `public int `[`LevelNumber`](#class_level_1a08e6603e6ab77dc1ca2d58c2ed8221a0) 

The level's number.

#### `public List< Vector2 > `[`positions`](#class_level_1a68bdb4fa6a0a7d317daaaf44c06599f2) 

#### `public delegate void `[`PlayerDead`](#class_level_1a963f02696507398ac850dcaee43ff321)`()` 

Emitted when the player dies.

#### `public delegate void `[`PlayerPerformedMainAction`](#class_level_1a9cb1b65bbf3e9ff796adf998f7b748d3)`()` 

Emitted when the player performs a main action.

#### `public delegate void `[`PlayerPickup`](#class_level_1afec3b7fef9b7c0c9e590b2ca2a47245c)`()` 

Emitted when the player pickups an action.

#### `public inline override void `[`_Ready`](#class_level_1a9b982efc154865a30a5c589d72f0a900)`()` 

#### `public inline override void `[`_Process`](#class_level_1adf87a658b5a922295a3bbab87f5820b5)`(float delta)` 

#### `public inline override void `[`_Draw`](#class_level_1ab147d68f7a06156f6a0cd595bf58f75d)`()` 

#### `public inline void `[`Restart`](#class_level_1a20b2f496054effcd20120b8cb37c14dc)`()` 

Restarts the level, resets the player's position and the hud.

#### `public inline void `[`UpdateProgress`](#class_level_1a209b18b3eef463ac8dc4caf19d869f11)`()` 

Calculates the progress that the player currently has on the level.

#### `public inline int `[`GetPoints`](#class_level_1a866f3830aa6da6db116ecd9204b1b7a6)`()` 

Gets the number of points that the player has earned on the current run.

#### Returns

#### `public inline void `[`MoveViewPort`](#class_level_1a37da9eda7a3cd74e5a8c4d5e92e83b18)`()` 

Moves the camera and the background to follow the player.

#### `public inline void `[`Pause`](#class_level_1ae81c01f79951151a432bbdbf1cdb3dd8)`()` 

Pauses the game.

#### `public inline void `[`SaveData`](#class_level_1a4bb15a932ab317c90d5de0623b9f8d88)`()` 

Saves the player's progress.

#### `public inline void `[`OnPlayerDead`](#class_level_1a6807430e5f1f262aca25e7bc40fbac90)`()` 

#### `public inline void `[`OnPlayerPickup`](#class_level_1a7c2ac37de0d423fa6c95bbce4b0eebf5)`()` 

#### `public inline void `[`OnPlayerPerformedMainAction`](#class_level_1a89dbf1585c31caa958aa431823f2f4f7)`()` 

#### `public inline void `[`OnHudPausePressed`](#class_level_1a08ef0cf0dd18af04729d4d01deaeea66)`()` 

#### `public inline void `[`OnHudPauseMouseEntered`](#class_level_1a2cd7ebf61994f7cc65f672f8cc0b20ae)`()` 

#### `public inline void `[`OnHudPauseMouseExited`](#class_level_1a462cabf043b2870fda20d5a7c25e6d40)`()` 

#### `public inline void `[`OnPauseMenuRestartPressed`](#class_level_1a4ecafdfb8a186ec3bffe2cae913616f8)`()` 

#### `public inline void `[`OnEndPositionBodyEntered`](#class_level_1aa0e6bfa6d80ec968a1995f395e016a0b)`(`[`Node`](#class_node)` body)` 

# class `LevelComplete` 

```
class LevelComplete
  : public NinePatchRect
```  

Menu that will be shown when a level is completed.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public delegate void `[`RestartPressed`](#class_level_complete_1a33f5684ecb7cf313659bfb2d058278b9)`()` | Signal that will be emitted when the restart button is pressed.
`public inline override void `[`_Ready`](#class_level_complete_1a8397e21dbd05d0c9bc69478135237be5)`()` | 
`public inline void `[`ShowMenu`](#class_level_complete_1a09a2c3c46fd610cd3796d716414b91f9)`()` | Pauses the game and shows this menu.
`public inline void `[`OnRestartPressed`](#class_level_complete_1a736a76d796cb5d33260b3d1cf3fabf5e)`()` | 
`public inline void `[`OnQuitPressed`](#class_level_complete_1ae371e0c7856213db9dcf898b0282d600)`()` | 

## Members

#### `public delegate void `[`RestartPressed`](#class_level_complete_1a33f5684ecb7cf313659bfb2d058278b9)`()` 

Signal that will be emitted when the restart button is pressed.

#### `public inline override void `[`_Ready`](#class_level_complete_1a8397e21dbd05d0c9bc69478135237be5)`()` 

#### `public inline void `[`ShowMenu`](#class_level_complete_1a09a2c3c46fd610cd3796d716414b91f9)`()` 

Pauses the game and shows this menu.

#### `public inline void `[`OnRestartPressed`](#class_level_complete_1a736a76d796cb5d33260b3d1cf3fabf5e)`()` 

#### `public inline void `[`OnQuitPressed`](#class_level_complete_1ae371e0c7856213db9dcf898b0282d600)`()` 

# class `LevelPicker` 

```
class LevelPicker
  : public SpinBox
```  

[Node](#class_node) for picking a level on the main menu.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public delegate void `[`ValueChanged`](#class_level_picker_1a84f75f77f3eee12ae2d7af73710cc673)`()` | Emitted when the player changes the value on this picker.
`public inline override void `[`_Ready`](#class_level_picker_1ac7749c15e37c52ad6d6ba7c1aaec7474)`()` | 
`public inline void `[`OnValueChanged`](#class_level_picker_1a1b5abdf1b94c7fe1410ca560a3eb247e)`(double value)` | 

## Members

#### `public delegate void `[`ValueChanged`](#class_level_picker_1a84f75f77f3eee12ae2d7af73710cc673)`()` 

Emitted when the player changes the value on this picker.

#### `public inline override void `[`_Ready`](#class_level_picker_1ac7749c15e37c52ad6d6ba7c1aaec7474)`()` 

#### `public inline void `[`OnValueChanged`](#class_level_picker_1a1b5abdf1b94c7fe1410ca560a3eb247e)`(double value)` 

# class `Main` 

```
class Main
  : public Node2D
```  

The main [Node](#class_node) of the game. It is a state machine that executes a single scene at a time.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} `[`Node2D`](#class_node2_d)` `[`Scene`](#class_main_1a9a9683bfcc0bfd6ab74ca38a1b6ad1ff) | The scene currently being executed. Can be profile select, main menu, level 1, level 2 or level 3.
`public inline override void `[`_Ready`](#class_main_1afa38a52a0b6f8e0362539aea9114f285)`()` | 
`public inline void `[`ChangeScene`](#class_main_1aff56bc272e79a2419d64fd18356b052b)`(`[`GameScenes`](#_game_scenes_8cs_1a0687e907db3af3681f90377d69f32090)` scene)` | Changes the currently active game scene and modifies the sounds currently being played accordingly.
`public inline void `[`OnPlayerDead`](#class_main_1a2d291164de57045d25f001c67e755396)`()` | 
`public inline void `[`OnPlayerPickup`](#class_main_1a5f0ade85d9f0190041de5c60d550a155)`()` | 
`public inline void `[`OnPlayerPerformedMainAction`](#class_main_1a40bec5344f137c03de6931c55fe19060)`()` | 

## Members

#### `{property} `[`Node2D`](#class_node2_d)` `[`Scene`](#class_main_1a9a9683bfcc0bfd6ab74ca38a1b6ad1ff) 

The scene currently being executed. Can be profile select, main menu, level 1, level 2 or level 3.

#### `public inline override void `[`_Ready`](#class_main_1afa38a52a0b6f8e0362539aea9114f285)`()` 

#### `public inline void `[`ChangeScene`](#class_main_1aff56bc272e79a2419d64fd18356b052b)`(`[`GameScenes`](#_game_scenes_8cs_1a0687e907db3af3681f90377d69f32090)` scene)` 

Changes the currently active game scene and modifies the sounds currently being played accordingly.

#### Parameters
* `scene` The new scene.

#### `public inline void `[`OnPlayerDead`](#class_main_1a2d291164de57045d25f001c67e755396)`()` 

#### `public inline void `[`OnPlayerPickup`](#class_main_1a5f0ade85d9f0190041de5c60d550a155)`()` 

#### `public inline void `[`OnPlayerPerformedMainAction`](#class_main_1a40bec5344f137c03de6931c55fe19060)`()` 

# class `MainAction` 

```
class MainAction
  : public PlayerState
```  

Class that represents an action the player can perform as main action.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} bool `[`OnActionPad`](#class_main_action_1a2149878bc7d0a4debaf0692581b990d4) | True if the player is currently on a jump pad.
`{property} bool `[`PerformingAction`](#class_main_action_1ae2d814bd2f2c5225e6c26fce2780accc) | True if the player is currently performing a main action.
`{property} bool `[`Blocked`](#class_main_action_1af4f38ae5810abac472752ba286622566) | Checks if the current action is blocked/disabled. If true, the action will not be performed on input events.
`public bool `[`CanUseActionPad`](#class_main_action_1a94fb5bad42a45b95401d737c0b4ebb22) | True if the player can use jump pads.
`public delegate void `[`Action`](#class_main_action_1a673b3a967faefc189251e4470b944fd4)`()` | Emitted if the player performs a main action.
`public inline virtual override void `[`_Init`](#class_main_action_1a5d77225f0db8bd9c5a5c1f120ef3ce95)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_StatePhysicsProcess`](#class_main_action_1ab2261aec55fea5dc4490545410b8b279)`(float delta)` | The physics process that will be called each frame for the state.
`public inline virtual void `[`_ActionOnGround`](#class_main_action_1a0d3e4403cb876a28ae3383daba402fce)`()` | 
`public inline virtual void `[`_ActionOnAir`](#class_main_action_1a61b3c6152e024c014e7d810feb94fc74)`()` | 
`public inline virtual void `[`_ActionReleased`](#class_main_action_1a9b80ccc09b82cb5b35dc22a1a6f9b85f)`()` | 
`public abstract void `[`_ActionProcess`](#class_main_action_1abad27d048abd3f377cf7f2e1e15f6975)`(float delta)` | The process that will be executed each frame while the action is being performed.
`public inline virtual void `[`OnMainActionTimerTimeout`](#class_main_action_1a17693bd0c6cc2a114af83d0f843baaa4)`()` | 
`public inline virtual void `[`OnMainActionObjectCollisionCheckAreaEntered`](#class_main_action_1a7171ab2e310ea4e2b6de08ca9e7c8a68)`(Area2D area)` | 
`public inline virtual void `[`OnMainActionObjectCollisionCheckAreaExited`](#class_main_action_1a2cb93724e1d5758c7544649f39bdcb67)`(Area2D area)` | 

## Members

#### `{property} bool `[`OnActionPad`](#class_main_action_1a2149878bc7d0a4debaf0692581b990d4) 

True if the player is currently on a jump pad.

#### `{property} bool `[`PerformingAction`](#class_main_action_1ae2d814bd2f2c5225e6c26fce2780accc) 

True if the player is currently performing a main action.

#### `{property} bool `[`Blocked`](#class_main_action_1af4f38ae5810abac472752ba286622566) 

Checks if the current action is blocked/disabled. If true, the action will not be performed on input events.

#### `public bool `[`CanUseActionPad`](#class_main_action_1a94fb5bad42a45b95401d737c0b4ebb22) 

True if the player can use jump pads.

#### `public delegate void `[`Action`](#class_main_action_1a673b3a967faefc189251e4470b944fd4)`()` 

Emitted if the player performs a main action.

#### `public inline virtual override void `[`_Init`](#class_main_action_1a5d77225f0db8bd9c5a5c1f120ef3ce95)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_StatePhysicsProcess`](#class_main_action_1ab2261aec55fea5dc4490545410b8b279)`(float delta)` 

The physics process that will be called each frame for the state.

#### Parameters
* `delta` Time since the last frame.

#### `public inline virtual void `[`_ActionOnGround`](#class_main_action_1a0d3e4403cb876a28ae3383daba402fce)`()` 

#### `public inline virtual void `[`_ActionOnAir`](#class_main_action_1a61b3c6152e024c014e7d810feb94fc74)`()` 

#### `public inline virtual void `[`_ActionReleased`](#class_main_action_1a9b80ccc09b82cb5b35dc22a1a6f9b85f)`()` 

#### `public abstract void `[`_ActionProcess`](#class_main_action_1abad27d048abd3f377cf7f2e1e15f6975)`(float delta)` 

The process that will be executed each frame while the action is being performed.

#### Parameters
* `delta` Time since last frame.

#### `public inline virtual void `[`OnMainActionTimerTimeout`](#class_main_action_1a17693bd0c6cc2a114af83d0f843baaa4)`()` 

#### `public inline virtual void `[`OnMainActionObjectCollisionCheckAreaEntered`](#class_main_action_1a7171ab2e310ea4e2b6de08ca9e7c8a68)`(Area2D area)` 

#### `public inline virtual void `[`OnMainActionObjectCollisionCheckAreaExited`](#class_main_action_1a2cb93724e1d5758c7544649f39bdcb67)`(Area2D area)` 

# class `MainActionPickup` 

```
class MainActionPickup
  : public Area2D
```  

Pickup for player main action.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} `[`PlayerMainAction`](#_player_main_action_8cs_1adbd1afd3268279088266e6463135cac9)` `[`Type`](#class_main_action_pickup_1a5fa73166a0ebf78db9eeb2221284b5e3) | The pickup's type.
`public inline override void `[`_Ready`](#class_main_action_pickup_1ace99a7be9c5d758c06c29cc28de73802)`()` | 

## Members

#### `{property} `[`PlayerMainAction`](#_player_main_action_8cs_1adbd1afd3268279088266e6463135cac9)` `[`Type`](#class_main_action_pickup_1a5fa73166a0ebf78db9eeb2221284b5e3) 

The pickup's type.

#### `public inline override void `[`_Ready`](#class_main_action_pickup_1ace99a7be9c5d758c06c29cc28de73802)`()` 

# class `MainMenu` 

```
class MainMenu
  : public Node2D
```  

The main menu of the game.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline override void `[`_Ready`](#class_main_menu_1a6e4d205f960117692bcee0d9708b3709)`()` | 
`public inline override void `[`_Process`](#class_main_menu_1a35a95291fb13d88d38f491c5a10fbd7a)`(float delta)` | 
`public inline void `[`UpdateUI`](#class_main_menu_1a17961f230885c7cb83f86bb88be4973c)`()` | 
`public inline void `[`OnPlayButtonPressed`](#class_main_menu_1a87e8abea9896111e446f12ac5acdb9db)`()` | 
`public inline void `[`OnProfileGUIShopPressed`](#class_main_menu_1a63d071fa78d43ba97f5f1044d43f952b)`()` | 
`public inline void `[`OnProfileGUIEditPressed`](#class_main_menu_1a7910c71982c6ae2e599b4ef8c7e5fed2)`()` | 
`public inline void `[`OnExitButtonPressed`](#class_main_menu_1af8ed217d174c1df8bb007112303ec7fb)`()` | 
`public inline void `[`OnProfileChanged`](#class_main_menu_1a399217040b4956e00f8983443bf18c83)`()` | 
`public inline void `[`OnLevelPickerValueChanged`](#class_main_menu_1a40a69fad4764d8777974773aad65fae5)`()` | 

## Members

#### `public inline override void `[`_Ready`](#class_main_menu_1a6e4d205f960117692bcee0d9708b3709)`()` 

#### `public inline override void `[`_Process`](#class_main_menu_1a35a95291fb13d88d38f491c5a10fbd7a)`(float delta)` 

#### `public inline void `[`UpdateUI`](#class_main_menu_1a17961f230885c7cb83f86bb88be4973c)`()` 

#### `public inline void `[`OnPlayButtonPressed`](#class_main_menu_1a87e8abea9896111e446f12ac5acdb9db)`()` 

#### `public inline void `[`OnProfileGUIShopPressed`](#class_main_menu_1a63d071fa78d43ba97f5f1044d43f952b)`()` 

#### `public inline void `[`OnProfileGUIEditPressed`](#class_main_menu_1a7910c71982c6ae2e599b4ef8c7e5fed2)`()` 

#### `public inline void `[`OnExitButtonPressed`](#class_main_menu_1af8ed217d174c1df8bb007112303ec7fb)`()` 

#### `public inline void `[`OnProfileChanged`](#class_main_menu_1a399217040b4956e00f8983443bf18c83)`()` 

#### `public inline void `[`OnLevelPickerValueChanged`](#class_main_menu_1a40a69fad4764d8777974773aad65fae5)`()` 

# class `MarginContainer` 

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `Node` 

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `Node2D` 

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `OnAirState` 

```
class OnAirState
  : public PersistentState
```  

Persisten state when the player is on air.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline virtual override void `[`_Init`](#class_on_air_state_1a4981def48203f62c802d6803e829fbbb)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_StatePhysicsProcess`](#class_on_air_state_1a8fc8b56eac0dd06f4976543b32420f57)`(float delta)` | The physics process that will be called each frame for the state.

## Members

#### `public inline virtual override void `[`_Init`](#class_on_air_state_1a4981def48203f62c802d6803e829fbbb)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_StatePhysicsProcess`](#class_on_air_state_1a8fc8b56eac0dd06f4976543b32420f57)`(float delta)` 

The physics process that will be called each frame for the state.

#### Parameters
* `delta` Time since the last frame.

# class `OnGroundState` 

```
class OnGroundState
  : public PersistentState
```  

Persistent state when the player is grounded.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline virtual override void `[`_Init`](#class_on_ground_state_1af9b72404be0c026cc9da18396aa214d2)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_StatePhysicsProcess`](#class_on_ground_state_1ab00fe4c5fbbe3d27cf9e7cdf726e2614)`(float delta)` | The physics process that will be called each frame for the state.

## Members

#### `public inline virtual override void `[`_Init`](#class_on_ground_state_1af9b72404be0c026cc9da18396aa214d2)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_StatePhysicsProcess`](#class_on_ground_state_1ab00fe4c5fbbe3d27cf9e7cdf726e2614)`(float delta)` 

The physics process that will be called each frame for the state.

#### Parameters
* `delta` Time since the last frame.

# class `Palette` 

Class that contains data related to colors.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} Color[] `[`PaletteColors`](#class_palette_1ac5cd23ad275bc2a794539c1208fb5318) | The available colors for avatar customization.
`{property} `[`Palette`](#class_palette)` `[`Instance`](#class_palette_1a25336192634062811d8659ee0ad065c6) | Gets the game's palette.
`public inline Texture `[`TextureFromColor`](#class_palette_1ab973750bb28f3de18132de170c08c092)`(int id,Vector2 size)` | Creates a rectangular shape and fills it with the color with the given id.

## Members

#### `{property} Color[] `[`PaletteColors`](#class_palette_1ac5cd23ad275bc2a794539c1208fb5318) 

The available colors for avatar customization.

#### `{property} `[`Palette`](#class_palette)` `[`Instance`](#class_palette_1a25336192634062811d8659ee0ad065c6) 

Gets the game's palette.

#### `public inline Texture `[`TextureFromColor`](#class_palette_1ab973750bb28f3de18132de170c08c092)`(int id,Vector2 size)` 

Creates a rectangular shape and fills it with the color with the given id.

#### Parameters
* `id` The color's id.

* `size` The rectangle's size.

#### Returns
An rectangular image texture filled with the color.

# class `PaletteSwapEntry` 

Class that contains fields needed for [Palette](#class_palette) swapping.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public Color `[`original`](#class_palette_swap_entry_1ac2f6caf7822e94b37b9f480901e2c813) | Original target color.
`public Color `[`newColor`](#class_palette_swap_entry_1afd787e859a6e32067d6203f78b95e457) | The color that the original will be swapped for.
`public Color `[`threshold`](#class_palette_swap_entry_1a98f303ecceb89ffec4c538c48269a4ec) | The threshold for swapping.
`public inline  `[`PaletteSwapEntry`](#class_palette_swap_entry_1a893a091f4487224ab631cfcc08d346c1)`(Color original,Color newColor,Color threshold)` | Creates a new palette swap entry.

## Members

#### `public Color `[`original`](#class_palette_swap_entry_1ac2f6caf7822e94b37b9f480901e2c813) 

Original target color.

#### `public Color `[`newColor`](#class_palette_swap_entry_1afd787e859a6e32067d6203f78b95e457) 

The color that the original will be swapped for.

#### `public Color `[`threshold`](#class_palette_swap_entry_1a98f303ecceb89ffec4c538c48269a4ec) 

The threshold for swapping.

#### `public inline  `[`PaletteSwapEntry`](#class_palette_swap_entry_1a893a091f4487224ab631cfcc08d346c1)`(Color original,Color newColor,Color threshold)` 

Creates a new palette swap entry.

#### Parameters
* `original` Original target color.

* `newColor` The threshold for swapping.

* `threshold` Creates a new palette swap entry.

# class `PaletteSwapShader` 

"Shader" for swapping colors in game textures.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} `[`PaletteSwapShader`](#class_palette_swap_shader)` `[`Instance`](#class_palette_swap_shader_1a339e9ac1c07f19e42fa8d80870566c83) | Gets the shader instance.
`public inline Image `[`PaletteSwap`](#class_palette_swap_shader_1ae747173cd2a85fa21e35129e67630275)`(Image image,List< `[`PaletteSwapEntry`](#class_palette_swap_entry)` > swaps)` | Performs a palette swap on the given image by calculating the difference between each pixel's color and the target colors to swap. Swaps each color whose difference with the target colors is smaller than the threshold.

## Members

#### `{property} `[`PaletteSwapShader`](#class_palette_swap_shader)` `[`Instance`](#class_palette_swap_shader_1a339e9ac1c07f19e42fa8d80870566c83) 

Gets the shader instance.

#### `public inline Image `[`PaletteSwap`](#class_palette_swap_shader_1ae747173cd2a85fa21e35129e67630275)`(Image image,List< `[`PaletteSwapEntry`](#class_palette_swap_entry)` > swaps)` 

Performs a palette swap on the given image by calculating the difference between each pixel's color and the target colors to swap. Swaps each color whose difference with the target colors is smaller than the threshold.

#### Parameters
* `image` The image in which to swap colors.

* `swaps` A list of the colors that will be swapped.

#### Returns

# class `PauseMenu` 

```
class PauseMenu
  : public NinePatchRect
```  

Menu that will be shown on pause.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public delegate void `[`RestartPressed`](#class_pause_menu_1a25d039f5d70d38933bdfe437a3e1c36c)`()` | Signal that will be emitted when the restart button is pressed.
`public inline override void `[`_Ready`](#class_pause_menu_1a4cc5227b00082bc3ea16922842ed6295)`()` | 
`public inline void `[`ShowMenu`](#class_pause_menu_1aae0eb58374e364f7b34d0750be250efa)`()` | Pauses the game and shows this menu.
`public inline void `[`OnCancelPressed`](#class_pause_menu_1a6329bddee55d0fb4211804e28c1d3a71)`()` | 
`public inline void `[`OnContinuePressed`](#class_pause_menu_1ad9b30c3c2ba00ffd78fe82e6592d30cc)`()` | 
`public inline void `[`OnRestartPressed`](#class_pause_menu_1a09b3095bfba6adfdf6511c6284653a5b)`()` | 
`public inline void `[`OnQuitPressed`](#class_pause_menu_1a2738ef11851cc818743920726ca7c148)`()` | 

## Members

#### `public delegate void `[`RestartPressed`](#class_pause_menu_1a25d039f5d70d38933bdfe437a3e1c36c)`()` 

Signal that will be emitted when the restart button is pressed.

#### `public inline override void `[`_Ready`](#class_pause_menu_1a4cc5227b00082bc3ea16922842ed6295)`()` 

#### `public inline void `[`ShowMenu`](#class_pause_menu_1aae0eb58374e364f7b34d0750be250efa)`()` 

Pauses the game and shows this menu.

#### `public inline void `[`OnCancelPressed`](#class_pause_menu_1a6329bddee55d0fb4211804e28c1d3a71)`()` 

#### `public inline void `[`OnContinuePressed`](#class_pause_menu_1ad9b30c3c2ba00ffd78fe82e6592d30cc)`()` 

#### `public inline void `[`OnRestartPressed`](#class_pause_menu_1a09b3095bfba6adfdf6511c6284653a5b)`()` 

#### `public inline void `[`OnQuitPressed`](#class_pause_menu_1a2738ef11851cc818743920726ca7c148)`()` 

# class `PersistentState` 

```
class PersistentState
  : public PlayerState
```  

Class that represents a player persistent state. Can be on air or on ground.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline virtual override void `[`_Init`](#class_persistent_state_1aa3bb922abb6c7a699b5990b1b9d83afc)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_StatePhysicsProcess`](#class_persistent_state_1a197779850b8a9fbef055982249582ef3)`(float delta)` | The physics process that will be called each frame for the state.
`public inline void `[`OnActionObjectCollisionCheckAreaEntered`](#class_persistent_state_1ae3c6d56cc272ef31022f735aa4888b86)`(Area2D area)` | 

## Members

#### `public inline virtual override void `[`_Init`](#class_persistent_state_1aa3bb922abb6c7a699b5990b1b9d83afc)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_StatePhysicsProcess`](#class_persistent_state_1a197779850b8a9fbef055982249582ef3)`(float delta)` 

The physics process that will be called each frame for the state.

#### Parameters
* `delta` Time since the last frame.

#### `public inline void `[`OnActionObjectCollisionCheckAreaEntered`](#class_persistent_state_1ae3c6d56cc272ef31022f735aa4888b86)`(Area2D area)` 

# class `Player` 

```
class Player
  : public KinematicBody2D
```  

The player node. It is a state machine that executes 3 states at each given time. The first state is a physical state (On ground, on air), while the other 2 are actions that the player can perform at a given time (Kind of like powers).

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} `[`PersistentState`](#class_persistent_state)` `[`PersistentState`](#class_player_1a9cb4641c4d481f73d88fb07d479f4c84) | The current persistent state of the player.
`{property} `[`MainAction`](#class_main_action)` `[`MainAction`](#class_player_1ab8b54cc99ed363971d75ab6c506016be) | The main action the player can currently perform.
`{property} `[`SecondaryAction`](#class_secondary_action)` `[`SecondaryAction`](#class_player_1aa21dcf6dffae0e8c8575890e4d8e6d07) | The secondary action the player can currently perform.
`{property} `[`PlayerMainAction`](#_player_main_action_8cs_1adbd1afd3268279088266e6463135cac9)` `[`MainActionType`](#class_player_1aa2d4269e3e9b3042032012c05502ff76) | The type of the main action that the player can currently execute.
`{property} `[`PlayerSecondaryAction`](#_player_secondary_action_8cs_1a92b46946fafc071a922f285614a74b88)` `[`SecondaryActionType`](#class_player_1ac3acd90d6c0eb2ee07ccec066d448cf7) | The type of the secondary action that the player can currently execute.
`{property} bool `[`Blocked`](#class_player_1a94853daaad74e83561ada70dc0c4e92e) | If true, then the player can't perform any actions.
`{property} bool `[`InvertedGravity`](#class_player_1a9c06a72ba615b0e764ad4ff428e8119d) | If true, then the player's gravity vector is inverted.
`{property} bool `[`Invincible`](#class_player_1af9af5996f690a82ffea195f2c9a46d0c) | If true, then the player can't die.
`public int `[`JumpForce`](#class_player_1acf06cc8b10f69a33e33f0750443e09bc) | The force/speed of the player's jump.
`public int `[`MovementSpeed`](#class_player_1a5a0c8762d9753c0108e520d2cd4c4194) | The player's movement speed.
`public float `[`MaxJumpTime`](#class_player_1a55a2743162dfad1ccf058979e3454cf0) | The maximum duration of the player's jump.
`public float `[`MaxFallSpeed`](#class_player_1af93facbeac2019c5bc7bfb2493041109) | The maximum falling speed of the player.
`public int `[`Gravity`](#class_player_1afa430a3e8bae8353eb0ed928c9919c95) | The player's gravity. This gets added each frame to the player's vertical linear velocity.
`public SpriteFrames `[`MaleAnimation`](#class_player_1a28f9ab1a1e2354fcb49c99fd618cf189) | Male character animations
`public SpriteFrames `[`FemaleAnimation`](#class_player_1a85fa6d18dc73ec6589821ac7dc59e9d2) | Female character animations
`public Area2D `[`jumpObjectCollisionCheck`](#class_player_1a4d70330236aa5cff44570ad6063433f0) | Area2D to check if the player has entered any jump objects.
`public Area2D `[`teleportCollisionCheck`](#class_player_1a4d0da6c92bf522df4a9d0b97b209b09b) | Area2D to check if the player will die on teleport.
`public Timer `[`secondaryActionTimer`](#class_player_1aa8a2d620862a3bff5e279a59eb8e1433) | Timer to perform event after a secondary action was executed.
`public Timer `[`mainActionTimer`](#class_player_1a0bb14eb9e541dc0cabe7e067931e2cde) | Timer to perform event after a main action was executed.
`public Timer `[`startTimer`](#class_player_1ab41212894186e98612be4e15d08ad121) | This timer enables input on the player on timeout.
`public AnimatedSprite `[`animation`](#class_player_1a8fc34dcdff8f033cb587661d07f13fa5) | The player's animation.
`public CollisionShape2D `[`runningCollision`](#class_player_1aa1f1a3e2e5bc1c6267dadd817f00af5d) | The player's default collision shape.
`public CollisionShape2D `[`rollingCollision`](#class_player_1ab5f7f8e003fed1e7b293f5b6f069648b) | The player's collision shape while performing a roll action.
`public Vector2 `[`linearVelocity`](#class_player_1adfe24c4a8a6124eef02a636f042917dd) | The player's linear velocity vector.
`public readonly int `[`DEFAULT_JUMPFORCE`](#class_player_1a79a2bd665eb8c1be87d3c4d16c7a17ca) | 
`public readonly int `[`DEFAULT_GRAVITY`](#class_player_1aaa96158303a2e4619809dd824b6002ec) | 
`public readonly int `[`DEFAULT_MOVEMENT_SPEED`](#class_player_1a1a02648b66f2ff24777751e242a260c0) | 
`public readonly float `[`DEFAULT_MAX_JUMP_TIME`](#class_player_1ae354c1568fb2f116e290e1a8fde5271a) | 
`public delegate void `[`Dead`](#class_player_1ad26d3c4010754f6af7948560a2a233c8)`()` | Emitted if the player dies.
`public delegate void `[`PerformedMainAction`](#class_player_1ab320c041982d83b5c79173ad1064f7be)`()` | Emitted when the player performs a main action.
`public delegate void `[`Pickup`](#class_player_1ac428e6908dd8a937cd060ec9f7d62814)`()` | Emitted when the player comes in contact with a pickup.
`public inline override void `[`_Ready`](#class_player_1ae192a478a80f0e93e01339d62cdd6f6d)`()` | 
`public inline override void `[`_PhysicsProcess`](#class_player_1a5c41f7a6b92001f593ccb5d8574371e5)`(float delta)` | 
`public inline void `[`ChangePersistentState`](#class_player_1ae2226638af8907c89812bdb4b7eefede)`(`[`PlayerPersistentState`](#_player_persistent_state_8cs_1ac15b5e32be30dad517e8866c7eb9af83)` state)` | Changes the current persistent state.
`public inline void `[`ChangeMainAction`](#class_player_1a383ca70b33e3f3a19573dc0c260c1150)`(`[`PlayerMainAction`](#_player_main_action_8cs_1adbd1afd3268279088266e6463135cac9)` action)` | Changes the current main action the player can perform.
`public inline void `[`ChangeSecondaryAction`](#class_player_1aa90d185e163489f864480c9c72b7fbb8)`(`[`PlayerSecondaryAction`](#_player_secondary_action_8cs_1a92b46946fafc071a922f285614a74b88)` action)` | Changes the current secondary action the player can perform.
`public inline void `[`InvertGravity`](#class_player_1ad50972081bd91a62aa2c099b27462d37)`()` | Invert's the player's gravity.
`public inline void `[`SetHitbox`](#class_player_1a4d955d72d1768541f5ac99f19ffe1381)`(`[`PlayerPersistentState`](#_player_persistent_state_8cs_1ac15b5e32be30dad517e8866c7eb9af83)` state)` | Sets a hitbox on the player depending on the state.
`public inline void `[`OnStartTimerTimeout`](#class_player_1a48409f2ac61578d5ed6a8acab3990da4)`()` | 
`public inline void `[`OnMainAction`](#class_player_1a04fe5bcf48f86e0a09f15e4ee623862a)`()` | 

## Members

#### `{property} `[`PersistentState`](#class_persistent_state)` `[`PersistentState`](#class_player_1a9cb4641c4d481f73d88fb07d479f4c84) 

The current persistent state of the player.

#### `{property} `[`MainAction`](#class_main_action)` `[`MainAction`](#class_player_1ab8b54cc99ed363971d75ab6c506016be) 

The main action the player can currently perform.

#### `{property} `[`SecondaryAction`](#class_secondary_action)` `[`SecondaryAction`](#class_player_1aa21dcf6dffae0e8c8575890e4d8e6d07) 

The secondary action the player can currently perform.

#### `{property} `[`PlayerMainAction`](#_player_main_action_8cs_1adbd1afd3268279088266e6463135cac9)` `[`MainActionType`](#class_player_1aa2d4269e3e9b3042032012c05502ff76) 

The type of the main action that the player can currently execute.

#### `{property} `[`PlayerSecondaryAction`](#_player_secondary_action_8cs_1a92b46946fafc071a922f285614a74b88)` `[`SecondaryActionType`](#class_player_1ac3acd90d6c0eb2ee07ccec066d448cf7) 

The type of the secondary action that the player can currently execute.

#### `{property} bool `[`Blocked`](#class_player_1a94853daaad74e83561ada70dc0c4e92e) 

If true, then the player can't perform any actions.

#### `{property} bool `[`InvertedGravity`](#class_player_1a9c06a72ba615b0e764ad4ff428e8119d) 

If true, then the player's gravity vector is inverted.

#### `{property} bool `[`Invincible`](#class_player_1af9af5996f690a82ffea195f2c9a46d0c) 

If true, then the player can't die.

#### `public int `[`JumpForce`](#class_player_1acf06cc8b10f69a33e33f0750443e09bc) 

The force/speed of the player's jump.

#### `public int `[`MovementSpeed`](#class_player_1a5a0c8762d9753c0108e520d2cd4c4194) 

The player's movement speed.

#### `public float `[`MaxJumpTime`](#class_player_1a55a2743162dfad1ccf058979e3454cf0) 

The maximum duration of the player's jump.

#### `public float `[`MaxFallSpeed`](#class_player_1af93facbeac2019c5bc7bfb2493041109) 

The maximum falling speed of the player.

#### `public int `[`Gravity`](#class_player_1afa430a3e8bae8353eb0ed928c9919c95) 

The player's gravity. This gets added each frame to the player's vertical linear velocity.

#### `public SpriteFrames `[`MaleAnimation`](#class_player_1a28f9ab1a1e2354fcb49c99fd618cf189) 

Male character animations

#### `public SpriteFrames `[`FemaleAnimation`](#class_player_1a85fa6d18dc73ec6589821ac7dc59e9d2) 

Female character animations

#### `public Area2D `[`jumpObjectCollisionCheck`](#class_player_1a4d70330236aa5cff44570ad6063433f0) 

Area2D to check if the player has entered any jump objects.

#### `public Area2D `[`teleportCollisionCheck`](#class_player_1a4d0da6c92bf522df4a9d0b97b209b09b) 

Area2D to check if the player will die on teleport.

#### `public Timer `[`secondaryActionTimer`](#class_player_1aa8a2d620862a3bff5e279a59eb8e1433) 

Timer to perform event after a secondary action was executed.

#### `public Timer `[`mainActionTimer`](#class_player_1a0bb14eb9e541dc0cabe7e067931e2cde) 

Timer to perform event after a main action was executed.

#### `public Timer `[`startTimer`](#class_player_1ab41212894186e98612be4e15d08ad121) 

This timer enables input on the player on timeout.

#### `public AnimatedSprite `[`animation`](#class_player_1a8fc34dcdff8f033cb587661d07f13fa5) 

The player's animation.

#### `public CollisionShape2D `[`runningCollision`](#class_player_1aa1f1a3e2e5bc1c6267dadd817f00af5d) 

The player's default collision shape.

#### `public CollisionShape2D `[`rollingCollision`](#class_player_1ab5f7f8e003fed1e7b293f5b6f069648b) 

The player's collision shape while performing a roll action.

#### `public Vector2 `[`linearVelocity`](#class_player_1adfe24c4a8a6124eef02a636f042917dd) 

The player's linear velocity vector.

#### `public readonly int `[`DEFAULT_JUMPFORCE`](#class_player_1a79a2bd665eb8c1be87d3c4d16c7a17ca) 

#### `public readonly int `[`DEFAULT_GRAVITY`](#class_player_1aaa96158303a2e4619809dd824b6002ec) 

#### `public readonly int `[`DEFAULT_MOVEMENT_SPEED`](#class_player_1a1a02648b66f2ff24777751e242a260c0) 

#### `public readonly float `[`DEFAULT_MAX_JUMP_TIME`](#class_player_1ae354c1568fb2f116e290e1a8fde5271a) 

#### `public delegate void `[`Dead`](#class_player_1ad26d3c4010754f6af7948560a2a233c8)`()` 

Emitted if the player dies.

#### `public delegate void `[`PerformedMainAction`](#class_player_1ab320c041982d83b5c79173ad1064f7be)`()` 

Emitted when the player performs a main action.

#### `public delegate void `[`Pickup`](#class_player_1ac428e6908dd8a937cd060ec9f7d62814)`()` 

Emitted when the player comes in contact with a pickup.

#### `public inline override void `[`_Ready`](#class_player_1ae192a478a80f0e93e01339d62cdd6f6d)`()` 

#### `public inline override void `[`_PhysicsProcess`](#class_player_1a5c41f7a6b92001f593ccb5d8574371e5)`(float delta)` 

#### `public inline void `[`ChangePersistentState`](#class_player_1ae2226638af8907c89812bdb4b7eefede)`(`[`PlayerPersistentState`](#_player_persistent_state_8cs_1ac15b5e32be30dad517e8866c7eb9af83)` state)` 

Changes the current persistent state.

#### Parameters
* `state` The new state.

#### `public inline void `[`ChangeMainAction`](#class_player_1a383ca70b33e3f3a19573dc0c260c1150)`(`[`PlayerMainAction`](#_player_main_action_8cs_1adbd1afd3268279088266e6463135cac9)` action)` 

Changes the current main action the player can perform.

#### Parameters
* `state` The new action.

#### `public inline void `[`ChangeSecondaryAction`](#class_player_1aa90d185e163489f864480c9c72b7fbb8)`(`[`PlayerSecondaryAction`](#_player_secondary_action_8cs_1a92b46946fafc071a922f285614a74b88)` action)` 

Changes the current secondary action the player can perform.

#### Parameters
* `state` The new action.

#### `public inline void `[`InvertGravity`](#class_player_1ad50972081bd91a62aa2c099b27462d37)`()` 

Invert's the player's gravity.

#### `public inline void `[`SetHitbox`](#class_player_1a4d955d72d1768541f5ac99f19ffe1381)`(`[`PlayerPersistentState`](#_player_persistent_state_8cs_1ac15b5e32be30dad517e8866c7eb9af83)` state)` 

Sets a hitbox on the player depending on the state.

#### Parameters
* `state` The player's state.

#### `public inline void `[`OnStartTimerTimeout`](#class_player_1a48409f2ac61578d5ed6a8acab3990da4)`()` 

#### `public inline void `[`OnMainAction`](#class_player_1a04fe5bcf48f86e0a09f15e4ee623862a)`()` 

# class `PlayerSession` 

Class that contains the the currently active profile.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} `[`Profile`](#class_profile)` `[`Profile`](#class_player_session_1a986345ec97ef2443cec013da3ae5b994) | Data of the active profile.
`{property} `[`PlayerSession`](#class_player_session)` `[`ActiveSession`](#class_player_session_1acb357efd7543bd1dee781de31e01e470) | Gets the singleton instance of the currently active profile.
`public inline void `[`Load`](#class_player_session_1a819cebf72563f1e27a78962f82fb9c72)`(int id)` | Loads a profile with the given id and makes it the active profile.
`public inline void `[`Save`](#class_player_session_1a8522ef9c8fc11562857f5a4a7955cca7)`()` | Saves the the currently active profile by writing to the save file.
`public inline void `[`LogOut`](#class_player_session_1a65808546d8278d30ee26af807c62051f)`()` | Logs out of the current profile.

## Members

#### `{property} `[`Profile`](#class_profile)` `[`Profile`](#class_player_session_1a986345ec97ef2443cec013da3ae5b994) 

Data of the active profile.

#### `{property} `[`PlayerSession`](#class_player_session)` `[`ActiveSession`](#class_player_session_1acb357efd7543bd1dee781de31e01e470) 

Gets the singleton instance of the currently active profile.

#### `public inline void `[`Load`](#class_player_session_1a819cebf72563f1e27a78962f82fb9c72)`(int id)` 

Loads a profile with the given id and makes it the active profile.

#### Parameters
* `id` The id of the profile to load.

#### `public inline void `[`Save`](#class_player_session_1a8522ef9c8fc11562857f5a4a7955cca7)`()` 

Saves the the currently active profile by writing to the save file.

#### `public inline void `[`LogOut`](#class_player_session_1a65808546d8278d30ee26af807c62051f)`()` 

Logs out of the current profile.

# class `PlayerState` 

```
class PlayerState
  : public Node2D
```  

Class that contains the base structure for a state that the player can have.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} `[`Player`](#class_player)` `[`Player`](#class_player_state_1a8fc13ad7ffde3b39b92acddabf17dc7b) | The player that owns the current state.
`public inline void `[`Setup`](#class_player_state_1a104dd6b861334c1c4f9cb2a9d322403c)`()` | Setups the state and initializes it.
`public abstract void `[`_StatePhysicsProcess`](#class_player_state_1a1bddd210d96db25cb49b3a0b3edd5265)`(float delta)` | The physics process that will be called each frame for the state.
`public abstract void `[`_Init`](#class_player_state_1a7c94c3f0cc97f388f281c524523d311e)`()` | Setups the state and initializes it.

## Members

#### `{property} `[`Player`](#class_player)` `[`Player`](#class_player_state_1a8fc13ad7ffde3b39b92acddabf17dc7b) 

The player that owns the current state.

#### `public inline void `[`Setup`](#class_player_state_1a104dd6b861334c1c4f9cb2a9d322403c)`()` 

Setups the state and initializes it.

#### `public abstract void `[`_StatePhysicsProcess`](#class_player_state_1a1bddd210d96db25cb49b3a0b3edd5265)`(float delta)` 

The physics process that will be called each frame for the state.

#### Parameters
* `delta` Time since the last frame.

#### `public abstract void `[`_Init`](#class_player_state_1a7c94c3f0cc97f388f281c524523d311e)`()` 

Setups the state and initializes it.

# class `PlayerStateFactory` 

This class generates states for the main class.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline `[`PersistentState`](#class_persistent_state)` `[`New`](#class_player_state_factory_1acd77aae65440dedcd2c6d26f3aedc985)`(`[`PlayerPersistentState`](#_player_persistent_state_8cs_1ac15b5e32be30dad517e8866c7eb9af83)` state)` | Creates a new persistent state from the given enum value.
`public inline `[`MainAction`](#class_main_action)` `[`New`](#class_player_state_factory_1ae6483f2ac3c4da7bb66d9e137048a18e)`(`[`PlayerMainAction`](#_player_main_action_8cs_1adbd1afd3268279088266e6463135cac9)` state)` | Creates a new player primary action from the given enum value.
`public inline `[`SecondaryAction`](#class_secondary_action)` `[`New`](#class_player_state_factory_1aabb3a8e0a40778ad8605262070ad0e79)`(`[`PlayerSecondaryAction`](#_player_secondary_action_8cs_1a92b46946fafc071a922f285614a74b88)` state)` | Creates a new secondary action from the given enum value.

## Members

#### `public inline `[`PersistentState`](#class_persistent_state)` `[`New`](#class_player_state_factory_1acd77aae65440dedcd2c6d26f3aedc985)`(`[`PlayerPersistentState`](#_player_persistent_state_8cs_1ac15b5e32be30dad517e8866c7eb9af83)` state)` 

Creates a new persistent state from the given enum value.

#### Parameters
* `state` The value of the new state.

#### Returns
A new instance of a player persistent state.

#### `public inline `[`MainAction`](#class_main_action)` `[`New`](#class_player_state_factory_1ae6483f2ac3c4da7bb66d9e137048a18e)`(`[`PlayerMainAction`](#_player_main_action_8cs_1adbd1afd3268279088266e6463135cac9)` state)` 

Creates a new player primary action from the given enum value.

#### Parameters
* `state` The value of the new primary action.

#### Returns
A new instance of a player primary action.

#### `public inline `[`SecondaryAction`](#class_secondary_action)` `[`New`](#class_player_state_factory_1aabb3a8e0a40778ad8605262070ad0e79)`(`[`PlayerSecondaryAction`](#_player_secondary_action_8cs_1a92b46946fafc071a922f285614a74b88)` state)` 

Creates a new secondary action from the given enum value.

#### Parameters
* `state` The value of the new secondary action.

#### Returns
A new instance of a player secondary action.

# class `PointsCounter` 

```
class PointsCounter
  : public MarginContainer
```  

[Node](#class_node) for displaying a number of points.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline override void `[`_Ready`](#class_points_counter_1a8e42096db3443ca5a566f1d6741f7c65)`()` | 
`public inline void `[`Set`](#class_points_counter_1a30a660fc6cb45333b015d6439bd7bc87)`(UInt32 points)` | Sets a new number of points to display.

## Members

#### `public inline override void `[`_Ready`](#class_points_counter_1a8e42096db3443ca5a566f1d6741f7c65)`()` 

#### `public inline void `[`Set`](#class_points_counter_1a30a660fc6cb45333b015d6439bd7bc87)`(UInt32 points)` 

Sets a new number of points to display.

#### Parameters
* `points` Number of points.

# class `Profile` 

Class that represents and contains the data of a player's profile.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} int `[`ID`](#class_profile_1a8907ef1053fdebaeb5322e09ffe38128) | The profile id. Can be any number between 0 and 5.
`{property} string `[`Name`](#class_profile_1a0e50ac0f5032687e6083e99749fcd199) | The profile name.
`{property} `[`Avatar`](#class_avatar)` `[`Avatar`](#class_profile_1a307f6749c751e25cef64f85b07f02514) | The profile's avatar.
`{property} UInt32 `[`Points`](#class_profile_1af87d47cc73db8b55b24e5ab547534272) | The number of points that the profile currently owns.
`{property} bool[] `[`OwnedItems`](#class_profile_1a3baa1f0b2ddbf6902dfdf4e06db2621a) | An array of booleans in which each index corresponds to a store item's id. Each element is true if the item was bought from the store and is currently owned and false otherwise.
`{property} int[] `[`LevelProgress`](#class_profile_1a63dd8c4295cf725a680ea5cb5e937137) | An array of ints that contains the maximum percent of progress the player has reached in each level. Element 0 is level 1, element 1 is level 2 and element 2 is level 3.
`{property} int `[`CurrentLevel`](#class_profile_1aabba37c3975118edacf08f6f51e9252d) | The level the player is currently in, that being the first level the player hasn't completed or level 3 if all have been completed.
`{property} List< int > `[`CompletedLevels`](#class_profile_1a54f4969aeceaac4db0be879867e71fe3) | A list of the levels the player has completed.
`{property} int `[`NumberOfOwnedItems`](#class_profile_1adaf86441cdfa02d937270c3cd466e2f8) | The number of items the player has bought from the store.
`public inline byte[] `[`ToBytes`](#class_profile_1a18281b870e1b5bb7aebc9bab50aa2272)`()` | Writes the profile data to an array of bytes for saving in a file.
`public inline bool `[`LevelIsUnlocked`](#class_profile_1adb3883e0f9a606c7e60b29dd2a41d8a0)`(int level)` | Checks if the level is unlocked, that is if the level's key has been bought from the store.

## Members

#### `{property} int `[`ID`](#class_profile_1a8907ef1053fdebaeb5322e09ffe38128) 

The profile id. Can be any number between 0 and 5.

#### `{property} string `[`Name`](#class_profile_1a0e50ac0f5032687e6083e99749fcd199) 

The profile name.

#### `{property} `[`Avatar`](#class_avatar)` `[`Avatar`](#class_profile_1a307f6749c751e25cef64f85b07f02514) 

The profile's avatar.

#### `{property} UInt32 `[`Points`](#class_profile_1af87d47cc73db8b55b24e5ab547534272) 

The number of points that the profile currently owns.

#### `{property} bool[] `[`OwnedItems`](#class_profile_1a3baa1f0b2ddbf6902dfdf4e06db2621a) 

An array of booleans in which each index corresponds to a store item's id. Each element is true if the item was bought from the store and is currently owned and false otherwise.

#### `{property} int[] `[`LevelProgress`](#class_profile_1a63dd8c4295cf725a680ea5cb5e937137) 

An array of ints that contains the maximum percent of progress the player has reached in each level. Element 0 is level 1, element 1 is level 2 and element 2 is level 3.

#### `{property} int `[`CurrentLevel`](#class_profile_1aabba37c3975118edacf08f6f51e9252d) 

The level the player is currently in, that being the first level the player hasn't completed or level 3 if all have been completed.

#### `{property} List< int > `[`CompletedLevels`](#class_profile_1a54f4969aeceaac4db0be879867e71fe3) 

A list of the levels the player has completed.

#### `{property} int `[`NumberOfOwnedItems`](#class_profile_1adaf86441cdfa02d937270c3cd466e2f8) 

The number of items the player has bought from the store.

#### `public inline byte[] `[`ToBytes`](#class_profile_1a18281b870e1b5bb7aebc9bab50aa2272)`()` 

Writes the profile data to an array of bytes for saving in a file.

#### Returns
A byte buffer containing the profile data

#### `public inline bool `[`LevelIsUnlocked`](#class_profile_1adb3883e0f9a606c7e60b29dd2a41d8a0)`(int level)` 

Checks if the level is unlocked, that is if the level's key has been bought from the store.

#### Parameters
* `level` The level's number.

#### Returns
True if the level is unlocked, else false.

# class `ProfileGUI` 

```
class ProfileGUI
  : public NinePatchRect
```  

Panel that displays the data of the currently active profile.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public delegate void `[`ShopPressed`](#class_profile_g_u_i_1a1cae5c390923b22eafb7abfa81a74767)`()` | Emitted when the shop button is pressed.
`public delegate void `[`EditPressed`](#class_profile_g_u_i_1a8c249c532bd0f7b6814dc4c6875d9050)`()` | Emitted when the edit profile button is pressed.
`public inline override void `[`_Ready`](#class_profile_g_u_i_1a6dc0dca54016fefc6c4919a7e372cf6e)`()` | 
`public inline void `[`UpdateUI`](#class_profile_g_u_i_1a63df12299905cd375c56ba1e2292dcd6)`()` | Updates the information currently displayed on the GUI.
`public inline void `[`OnShopPressed`](#class_profile_g_u_i_1a590b9e765f2e1a195e65235798dd5fa4)`()` | 
`public inline void `[`OnEditPressed`](#class_profile_g_u_i_1a7ce6425fc897f70f57a3a342e699a72b)`()` | 
`public inline void `[`OnLogOutPressed`](#class_profile_g_u_i_1ad835b6812c257c3f5c9c6a23892e0770)`()` | 

## Members

#### `public delegate void `[`ShopPressed`](#class_profile_g_u_i_1a1cae5c390923b22eafb7abfa81a74767)`()` 

Emitted when the shop button is pressed.

#### `public delegate void `[`EditPressed`](#class_profile_g_u_i_1a8c249c532bd0f7b6814dc4c6875d9050)`()` 

Emitted when the edit profile button is pressed.

#### `public inline override void `[`_Ready`](#class_profile_g_u_i_1a6dc0dca54016fefc6c4919a7e372cf6e)`()` 

#### `public inline void `[`UpdateUI`](#class_profile_g_u_i_1a63df12299905cd375c56ba1e2292dcd6)`()` 

Updates the information currently displayed on the GUI.

#### `public inline void `[`OnShopPressed`](#class_profile_g_u_i_1a590b9e765f2e1a195e65235798dd5fa4)`()` 

#### `public inline void `[`OnEditPressed`](#class_profile_g_u_i_1a7ce6425fc897f70f57a3a342e699a72b)`()` 

#### `public inline void `[`OnLogOutPressed`](#class_profile_g_u_i_1ad835b6812c257c3f5c9c6a23892e0770)`()` 

# class `ProfileSelect` 

```
class ProfileSelect
  : public Node2D
```  

Scene that displays a menu where profiles can be created, loaded and deleted.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline override void `[`_Ready`](#class_profile_select_1a515df791d64afdf822a4b385694808f2)`()` | 
`public inline override void `[`_Process`](#class_profile_select_1a7a6b440025c061ead559d5a832a4ed42)`(float delta)` | 

## Members

#### `public inline override void `[`_Ready`](#class_profile_select_1a515df791d64afdf822a4b385694808f2)`()` 

#### `public inline override void `[`_Process`](#class_profile_select_1a7a6b440025c061ead559d5a832a4ed42)`(float delta)` 

# class `ProfileSelectEntry` 

```
class ProfileSelectEntry
  : public Button
```  

[Button](#class_button) that and allows the profile to be selected and displays a profile's data.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public int `[`ProfileID`](#class_profile_select_entry_1a1f010ec4952fdc771b4e352c84d4087e) | The profile's id.
`public inline override void `[`_Ready`](#class_profile_select_entry_1a3dc12cffc1e411b67207e361ce674692)`()` | 
`public inline void `[`UpdateUI`](#class_profile_select_entry_1a455e5a4a8662aea7e31b6492fb437b50)`()` | Updates the data currently displayed on the button.
`public inline void `[`OnDeletePressed`](#class_profile_select_entry_1adadc348a0e9eb9a3c0cc64417b66f0a4)`()` | 
`public inline void `[`OnDeleteDialogConfirmed`](#class_profile_select_entry_1ae2810d40cdca8a83f0cf442006bfaa9e)`()` | 
`public inline void `[`OnCreateDialogCreationFailed`](#class_profile_select_entry_1abf344a648fc7e68522a3181a6664c26c)`()` | 
`public inline void `[`OnPressed`](#class_profile_select_entry_1a88978332d17f63b02b3dc4476e01c6a4)`()` | 

## Members

#### `public int `[`ProfileID`](#class_profile_select_entry_1a1f010ec4952fdc771b4e352c84d4087e) 

The profile's id.

#### `public inline override void `[`_Ready`](#class_profile_select_entry_1a3dc12cffc1e411b67207e361ce674692)`()` 

#### `public inline void `[`UpdateUI`](#class_profile_select_entry_1a455e5a4a8662aea7e31b6492fb437b50)`()` 

Updates the data currently displayed on the button.

#### `public inline void `[`OnDeletePressed`](#class_profile_select_entry_1adadc348a0e9eb9a3c0cc64417b66f0a4)`()` 

#### `public inline void `[`OnDeleteDialogConfirmed`](#class_profile_select_entry_1ae2810d40cdca8a83f0cf442006bfaa9e)`()` 

#### `public inline void `[`OnCreateDialogCreationFailed`](#class_profile_select_entry_1abf344a648fc7e68522a3181a6664c26c)`()` 

#### `public inline void `[`OnPressed`](#class_profile_select_entry_1a88978332d17f63b02b3dc4476e01c6a4)`()` 

# class `SaveFileInfo` 

Static class that contains some constants about save file structure.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `SceneFactory` 

This class generates scenes for the main class.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline  `[`SceneFactory`](#class_scene_factory_1a079c0b6302987a374a561495752bfdc7)`()` | Creates a new scene factory. Loads each scene and stores it in the scenes dictionary.
`public inline `[`Node2D`](#class_node2_d)` `[`New`](#class_scene_factory_1aa71c8ef1cc97cc029f7b54512187ae7d)`(`[`GameScenes`](#_game_scenes_8cs_1a0687e907db3af3681f90377d69f32090)` scene)` | Creates a new scene.

## Members

#### `public inline  `[`SceneFactory`](#class_scene_factory_1a079c0b6302987a374a561495752bfdc7)`()` 

Creates a new scene factory. Loads each scene and stores it in the scenes dictionary.

#### `public inline `[`Node2D`](#class_node2_d)` `[`New`](#class_scene_factory_1aa71c8ef1cc97cc029f7b54512187ae7d)`(`[`GameScenes`](#_game_scenes_8cs_1a0687e907db3af3681f90377d69f32090)` scene)` 

Creates a new scene.

#### Parameters
* `scene` The enum value of the scene to create.

#### Returns
A new instance of the scene.

# class `SecondaryAction` 

```
class SecondaryAction
  : public PlayerState
```  

Class that represents an action the player can perform as secondary action.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} bool `[`Blocked`](#class_secondary_action_1a6234d64fc4dbfb25eb8791f0e5cd470d) | Checks if the current action is blocked/disabled. If true, the action will not be performed on input events.
`public inline virtual override void `[`_Init`](#class_secondary_action_1a82ec8c6b3487e5507aa926f412d76945)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_StatePhysicsProcess`](#class_secondary_action_1a91411ef181aa4993006fcb37cc70225d)`(float delta)` | The physics process that will be called each frame for the state.
`public inline virtual void `[`_ActionOnGround`](#class_secondary_action_1a2d779a636107f20c7b8566d359d47e2c)`()` | The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.
`public abstract void `[`_ActionOnAir`](#class_secondary_action_1a70a639090f6e4f4b92b0116a21484673)`()` | The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.
`public inline virtual void `[`_ActionReleased`](#class_secondary_action_1a167568a42e1a355f2d49b5a9dcfd4baf)`()` | The action that will be executed once the player stops pressing the action's input keyboard/mouse buttons.
`public inline virtual void `[`OnSecondaryActionTimerTimeout`](#class_secondary_action_1ab1436a4c4523473d3199412de76ec830)`()` | 

## Members

#### `{property} bool `[`Blocked`](#class_secondary_action_1a6234d64fc4dbfb25eb8791f0e5cd470d) 

Checks if the current action is blocked/disabled. If true, the action will not be performed on input events.

#### `public inline virtual override void `[`_Init`](#class_secondary_action_1a82ec8c6b3487e5507aa926f412d76945)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_StatePhysicsProcess`](#class_secondary_action_1a91411ef181aa4993006fcb37cc70225d)`(float delta)` 

The physics process that will be called each frame for the state.

#### Parameters
* `delta` Time since the last frame.

#### `public inline virtual void `[`_ActionOnGround`](#class_secondary_action_1a2d779a636107f20c7b8566d359d47e2c)`()` 

The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.

#### `public abstract void `[`_ActionOnAir`](#class_secondary_action_1a70a639090f6e4f4b92b0116a21484673)`()` 

The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.

#### `public inline virtual void `[`_ActionReleased`](#class_secondary_action_1a167568a42e1a355f2d49b5a9dcfd4baf)`()` 

The action that will be executed once the player stops pressing the action's input keyboard/mouse buttons.

#### `public inline virtual void `[`OnSecondaryActionTimerTimeout`](#class_secondary_action_1ab1436a4c4523473d3199412de76ec830)`()` 

# class `SecondaryActionPickup` 

```
class SecondaryActionPickup
  : public Area2D
```  

Pickup for player secondary action.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`{property} `[`PlayerSecondaryAction`](#_player_secondary_action_8cs_1a92b46946fafc071a922f285614a74b88)` `[`Type`](#class_secondary_action_pickup_1a0a202dab78d2f57ab0fc26ee01c74db2) | The pickup's type.
`public inline override void `[`_Ready`](#class_secondary_action_pickup_1ac6f8adbcf3675f978c5467ea06ae6ea8)`()` | 

## Members

#### `{property} `[`PlayerSecondaryAction`](#_player_secondary_action_8cs_1a92b46946fafc071a922f285614a74b88)` `[`Type`](#class_secondary_action_pickup_1a0a202dab78d2f57ab0fc26ee01c74db2) 

The pickup's type.

#### `public inline override void `[`_Ready`](#class_secondary_action_pickup_1ac6f8adbcf3675f978c5467ea06ae6ea8)`()` 

# class `ShopGUI` 

```
class ShopGUI
  : public NinePatchRect
```  

The shop from which the player can buy items.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public delegate void `[`ProfileChanged`](#class_shop_g_u_i_1a3afd1cedc36ef4900dcd83db77fc50d9)`()` | Emitted if the player profile changed. (If an item was bought)
`public inline override void `[`_Ready`](#class_shop_g_u_i_1a070d5686e3639f599db4dad0ac5675f1)`()` | 
`public inline void `[`OnItemButtonPressed`](#class_shop_g_u_i_1a16b59adaaf6be46aaf26fd1ae39bf982)`()` | 
`public inline void `[`OnCancelPressed`](#class_shop_g_u_i_1ab993141e4f22e2df8e1c7239da6f4828)`()` | 
`public inline void `[`OnBuyPressed`](#class_shop_g_u_i_1ac7b20c05193df04c7c0d9387823a11cf)`()` | 

## Members

#### `public delegate void `[`ProfileChanged`](#class_shop_g_u_i_1a3afd1cedc36ef4900dcd83db77fc50d9)`()` 

Emitted if the player profile changed. (If an item was bought)

#### `public inline override void `[`_Ready`](#class_shop_g_u_i_1a070d5686e3639f599db4dad0ac5675f1)`()` 

#### `public inline void `[`OnItemButtonPressed`](#class_shop_g_u_i_1a16b59adaaf6be46aaf26fd1ae39bf982)`()` 

#### `public inline void `[`OnCancelPressed`](#class_shop_g_u_i_1ab993141e4f22e2df8e1c7239da6f4828)`()` 

#### `public inline void `[`OnBuyPressed`](#class_shop_g_u_i_1ac7b20c05193df04c7c0d9387823a11cf)`()` 

# class `SpawnedPlatform` 

```
class SpawnedPlatform
  : public StaticBody2D
```  

Platforms that the player can spawn with the spawn platforms secondary action. They destroy themselves after half a second.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline override void `[`_Ready`](#class_spawned_platform_1a5e915c7b81f6b338b20e3fd92c7bcad5)`()` | 
`public inline void `[`OnDestroyTimerTimeout`](#class_spawned_platform_1a68da967a2be8ba98d0909e05304ba71f)`()` | 

## Members

#### `public inline override void `[`_Ready`](#class_spawned_platform_1a5e915c7b81f6b338b20e3fd92c7bcad5)`()` 

#### `public inline void `[`OnDestroyTimerTimeout`](#class_spawned_platform_1a68da967a2be8ba98d0909e05304ba71f)`()` 

# class `SpawnPlatforms` 

```
class SpawnPlatforms
  : public SecondaryAction
```  

Secondary action that allows the player to spawn platforms while on air.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public PackedScene `[`PlatformScene`](#class_spawn_platforms_1a907b6a7456095772af3765d68af5cdc4) | The platforms that can be spawned.
`public inline virtual override void `[`_Init`](#class_spawn_platforms_1a223516f8a535749e901f616dd804bb4f)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_ActionOnGround`](#class_spawn_platforms_1a2a9b1a8f7dc1af458b60059ba08bc847)`()` | The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.
`public inline virtual override void `[`_ActionOnAir`](#class_spawn_platforms_1ae11d1949e82b9a316f530ac977d432b8)`()` | The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.
`public inline virtual override void `[`_ActionReleased`](#class_spawn_platforms_1a3eeaa79c708598234334fda9cb7f156e)`()` | The action that will be executed once the player stops pressing the action's input keyboard/mouse buttons.
`public inline virtual override void `[`OnSecondaryActionTimerTimeout`](#class_spawn_platforms_1a6c1b2b02211d0597d497209ae78ddca0)`()` | 

## Members

#### `public PackedScene `[`PlatformScene`](#class_spawn_platforms_1a907b6a7456095772af3765d68af5cdc4) 

The platforms that can be spawned.

#### `public inline virtual override void `[`_Init`](#class_spawn_platforms_1a223516f8a535749e901f616dd804bb4f)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_ActionOnGround`](#class_spawn_platforms_1a2a9b1a8f7dc1af458b60059ba08bc847)`()` 

The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.

#### `public inline virtual override void `[`_ActionOnAir`](#class_spawn_platforms_1ae11d1949e82b9a316f530ac977d432b8)`()` 

The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.

#### `public inline virtual override void `[`_ActionReleased`](#class_spawn_platforms_1a3eeaa79c708598234334fda9cb7f156e)`()` 

The action that will be executed once the player stops pressing the action's input keyboard/mouse buttons.

#### `public inline virtual override void `[`OnSecondaryActionTimerTimeout`](#class_spawn_platforms_1a6c1b2b02211d0597d497209ae78ddca0)`()` 

# class `SpinBox` 

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `StaticBody2D` 

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------

## Members

# class `SwitchGravity` 

```
class SwitchGravity
  : public SecondaryAction
```  

Secondary action that allows the player to invert the direction of gravity.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline virtual override void `[`_Init`](#class_switch_gravity_1ae2eeee76ac6fd739b6181e1d80bcf54b)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_StatePhysicsProcess`](#class_switch_gravity_1a2d96d7d7d7c08aed0d22908002299ddc)`(float delta)` | The physics process that will be called each frame for the state.
`public inline virtual override void `[`_ActionOnGround`](#class_switch_gravity_1a3266c22e1cce5dfc640584b53dcd31d8)`()` | The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.
`public inline virtual override void `[`_ActionOnAir`](#class_switch_gravity_1a79517966cb67a2f3282bdcaf1fbaaf76)`()` | The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.
`public inline virtual override void `[`_ActionReleased`](#class_switch_gravity_1a21fcb39af6df6d3786a2843d1e7cfcbb)`()` | The action that will be executed once the player stops pressing the action's input keyboard/mouse buttons.
`public inline virtual override void `[`OnSecondaryActionTimerTimeout`](#class_switch_gravity_1a92a60def3fa4553e04f9511c3e892be6)`()` | 
`public inline void `[`invertGravity`](#class_switch_gravity_1abe70d5f88766890c9a0dc52de21e931b)`()` | Invert's the player's gravity.

## Members

#### `public inline virtual override void `[`_Init`](#class_switch_gravity_1ae2eeee76ac6fd739b6181e1d80bcf54b)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_StatePhysicsProcess`](#class_switch_gravity_1a2d96d7d7d7c08aed0d22908002299ddc)`(float delta)` 

The physics process that will be called each frame for the state.

#### Parameters
* `delta` Time since the last frame.

#### `public inline virtual override void `[`_ActionOnGround`](#class_switch_gravity_1a3266c22e1cce5dfc640584b53dcd31d8)`()` 

The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.

#### `public inline virtual override void `[`_ActionOnAir`](#class_switch_gravity_1a79517966cb67a2f3282bdcaf1fbaaf76)`()` 

The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.

#### `public inline virtual override void `[`_ActionReleased`](#class_switch_gravity_1a21fcb39af6df6d3786a2843d1e7cfcbb)`()` 

The action that will be executed once the player stops pressing the action's input keyboard/mouse buttons.

#### `public inline virtual override void `[`OnSecondaryActionTimerTimeout`](#class_switch_gravity_1a92a60def3fa4553e04f9511c3e892be6)`()` 

#### `public inline void `[`invertGravity`](#class_switch_gravity_1abe70d5f88766890c9a0dc52de21e931b)`()` 

Invert's the player's gravity.

# class `Teleport` 

```
class Teleport
  : public MainAction
```  

[Main](#class_main) action that allows the player to teleport a small distance above them.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public int `[`TELEPORT_DISTANCE`](#class_teleport_1a4262864228863630057ea5411f0b992b) | Default teleport distance.
`public inline virtual override void `[`_Init`](#class_teleport_1ac3436447bedf6cb700213b8c7f9641df)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_ActionOnGround`](#class_teleport_1aa1335939a5f0597c9bf0cbb0ff418220)`()` | 
`public inline virtual override void `[`_ActionOnAir`](#class_teleport_1a0e8ff81f32dd5408d50ab5881fe6a2f6)`()` | 
`public inline virtual override void `[`_ActionReleased`](#class_teleport_1a777418072ec29926a6c0bb7596782952)`()` | 
`public inline virtual override void `[`_ActionProcess`](#class_teleport_1ab64216d083c55dfc26ed7f236ed34a03)`(float delta)` | The process that will be executed each frame while the action is being performed.
`public inline virtual override void `[`OnMainActionObjectCollisionCheckAreaEntered`](#class_teleport_1ae1d16e9d16358e23e6ae55b942d1f312)`(Area2D area)` | 
`public inline virtual override void `[`OnMainActionTimerTimeout`](#class_teleport_1ab8724fd67974a34636592398ba31beac)`()` | 

## Members

#### `public int `[`TELEPORT_DISTANCE`](#class_teleport_1a4262864228863630057ea5411f0b992b) 

Default teleport distance.

#### `public inline virtual override void `[`_Init`](#class_teleport_1ac3436447bedf6cb700213b8c7f9641df)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_ActionOnGround`](#class_teleport_1aa1335939a5f0597c9bf0cbb0ff418220)`()` 

#### `public inline virtual override void `[`_ActionOnAir`](#class_teleport_1a0e8ff81f32dd5408d50ab5881fe6a2f6)`()` 

#### `public inline virtual override void `[`_ActionReleased`](#class_teleport_1a777418072ec29926a6c0bb7596782952)`()` 

#### `public inline virtual override void `[`_ActionProcess`](#class_teleport_1ab64216d083c55dfc26ed7f236ed34a03)`(float delta)` 

The process that will be executed each frame while the action is being performed.

#### Parameters
* `delta` Time since last frame.

#### `public inline virtual override void `[`OnMainActionObjectCollisionCheckAreaEntered`](#class_teleport_1ae1d16e9d16358e23e6ae55b942d1f312)`(Area2D area)` 

#### `public inline virtual override void `[`OnMainActionTimerTimeout`](#class_teleport_1ab8724fd67974a34636592398ba31beac)`()` 

# class `TeleportAndSwitchGravity` 

```
class TeleportAndSwitchGravity
  : public SecondaryAction
```  

Secondary action that allows the player to teleport and invert the direction of gravity.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public inline virtual override void `[`_Init`](#class_teleport_and_switch_gravity_1a5a48df9387198b5ea63957f884a513f8)`()` | Setups the state and initializes it.
`public inline virtual override void `[`_ActionOnGround`](#class_teleport_and_switch_gravity_1aa307d371dea032532bf619e102972791)`()` | The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.
`public inline virtual override void `[`_ActionOnAir`](#class_teleport_and_switch_gravity_1ad74396e09855f299b756fd9a11ea95b9)`()` | The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.
`public inline virtual override void `[`_ActionReleased`](#class_teleport_and_switch_gravity_1ab8ef1a89a937fb3a90c88b65d4c028bb)`()` | The action that will be executed once the player stops pressing the action's input keyboard/mouse buttons.
`public inline virtual override void `[`OnSecondaryActionTimerTimeout`](#class_teleport_and_switch_gravity_1afb088693fcb444dc8a536a1f37988a53)`()` | 
`public inline void `[`invertGravity`](#class_teleport_and_switch_gravity_1a49809a107376cd8ad243ca3631c258a4)`()` | Invert's the player's gravity.

## Members

#### `public inline virtual override void `[`_Init`](#class_teleport_and_switch_gravity_1a5a48df9387198b5ea63957f884a513f8)`()` 

Setups the state and initializes it.

#### `public inline virtual override void `[`_ActionOnGround`](#class_teleport_and_switch_gravity_1aa307d371dea032532bf619e102972791)`()` 

The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.

#### `public inline virtual override void `[`_ActionOnAir`](#class_teleport_and_switch_gravity_1ad74396e09855f299b756fd9a11ea95b9)`()` 

The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.

#### `public inline virtual override void `[`_ActionReleased`](#class_teleport_and_switch_gravity_1ab8ef1a89a937fb3a90c88b65d4c028bb)`()` 

The action that will be executed once the player stops pressing the action's input keyboard/mouse buttons.

#### `public inline virtual override void `[`OnSecondaryActionTimerTimeout`](#class_teleport_and_switch_gravity_1afb088693fcb444dc8a536a1f37988a53)`()` 

#### `public inline void `[`invertGravity`](#class_teleport_and_switch_gravity_1a49809a107376cd8ad243ca3631c258a4)`()` 

Invert's the player's gravity.

# class `TileSetMaker` 

```
class TileSetMaker
  : public Node
```  

[Node](#class_node) for making tilesets from an image.

## Summary

 Members                        | Descriptions                                
--------------------------------|---------------------------------------------
`public Vector2 `[`TileSize`](#class_tile_set_maker_1add080d0b5e2582cd3bfe8b7a534ea7a3) | The size of each tile.
`public Texture `[`Texture`](#class_tile_set_maker_1a9150369a075015feebbf166531104343) | The image texture from which to create the tileset.
`public string `[`FilePath`](#class_tile_set_maker_1a7d9c284c8bd5000e02f397ea7e424d05) | The path where the tileset will be save.
`public inline override void `[`_Ready`](#class_tile_set_maker_1ac9c5ff19e7996d296485ecd5a440ec13)`()` | 

## Members

#### `public Vector2 `[`TileSize`](#class_tile_set_maker_1add080d0b5e2582cd3bfe8b7a534ea7a3) 

The size of each tile.

#### `public Texture `[`Texture`](#class_tile_set_maker_1a9150369a075015feebbf166531104343) 

The image texture from which to create the tileset.

#### `public string `[`FilePath`](#class_tile_set_maker_1a7d9c284c8bd5000e02f397ea7e424d05) 

The path where the tileset will be save.

#### `public inline override void `[`_Ready`](#class_tile_set_maker_1ac9c5ff19e7996d296485ecd5a440ec13)`()` 

Generated by [Moxygen](https://sourcey.com/moxygen)