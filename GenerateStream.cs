using Godot;
using System;

public partial class GenerateStream : AudioStreamPlayer
{
    float sampleHz = 44100;
    float pulseHz = 440;
    float phase = 0;

    AudioStreamGeneratorPlayback playback;

    public override void _EnterTree()
    {
        AudioStreamGenerator generator = GD.Load<AudioStreamGenerator>("res://resource/generator.tres");
        generator.MixRate = sampleHz;
        playback = (AudioStreamGeneratorPlayback)this.GetStreamPlayback();
    }

    public override void _Ready()
    {

        FillBuffer();
        this.Play();
    }

    public override void _Process(float delta)
    {
        FillBuffer();
    }

    public void FillBuffer()
    {
        float increment = pulseHz / sampleHz;

        int toFill = playback.GetFramesAvailable();

        while (toFill > 0)
        {
            //fill sine wave
            //playback.PushFrame(Vector2.One * Mathf.Sin(phase * Mathf.Tau));

            //fill triangle wave
            playback.PushFrame(Vector2.One * (Mathf.Asin(Mathf.Abs(Mathf.Sin((phase + Mathf.Pi / 2) / 2)) - Mathf.Pi / 4)));

            phase = (phase + increment) % 1.0f;
            toFill -= 1;
        }
    }
}
