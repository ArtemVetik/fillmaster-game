﻿
namespace AV.FillMaster.Application
{
    public interface IEndOfGameView
    {
        Task RenderWin();
        Task RenderLose();
    }
}