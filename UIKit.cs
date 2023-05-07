using Godot;
using System;

public partial class UIKit : Node
{
    [Export]
    public NodePath offPath, sinePath, trianglePath, rectPath, audioStreamPlayerPath;

    Button off, sine, triangle, rect;

    AudioStreamPlayer audioStreamPlayer;

    public override void _EnterTree()
    {
        GetNode();
        ConnectSignal();
    }

    public void GetNode()
    {
        off = GetNode<Button>(offPath);
        sine = GetNode<Button>(sinePath);
        triangle = GetNode<Button>(trianglePath);
        rect = GetNode<Button>(rectPath);

        audioStreamPlayer = GetNode<AudioStreamPlayer>(audioStreamPlayerPath);
    }

    private void ConnectSignal()
    {
        off.Connect("toggled",new Callable(audioStreamPlayer,"PlayAndPause"),new Godot.Collections.Array() { "off" });
    }
}
