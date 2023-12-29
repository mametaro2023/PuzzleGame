using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DxLibDLL;

namespace VisualStudio2015
{
    class Program
    {
        static readonly int TIMER_INTERVAL = 16;
        static readonly int FIELD_WIDTH = 8;
        static readonly int FIELD_HEIGHT = 15;
        static readonly int BLOCK_SIZE = 32;
        static int mTimer;
        static Block block = new Block();
        static Three_Blocks three_blocks = new Three_Blocks();
        static int background;

        static void Init()
        {
            DX.SetMainWindowText("puzzle");//タイトル名
            DX.SetOutApplicationLogValidFlag(DX.FALSE);//ログ非表示
            DX.ChangeWindowMode(DX.TRUE);//ウィンドウモードにする
            DX.SetGraphMode(1280, 720, 32); //ウィンドウサイズと色ビットの調整 
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);//裏画面設定

            if (DX.DxLib_Init() < 0)// ＤＸライブラリの初期化
            {
                return;
            }
        }



        static void Load()
        {
            
            block.LBlocks();//ブロックの読み込み
            //background = DX.LoadGraph("Images\\frame\\background.png");//backgroundは8:15にしなければならない
        }

        static void Draw()
        {
            block.DBlocks(0,0,3);
            //DX.DrawGraph(62, 62, background, DX.FALSE);
            three_blocks.DBlocks(15, 15);
            DX.ScreenFlip();
        }

        static void Loop()
        {
            // メインループ
            while (DX.ProcessMessage() != -1)
            {
                mTimer += TIMER_INTERVAL;
                //DX.WaitTimer

               
            }
        }

        static void Main()//メイン関数
        {
            Init();
            Load();
            Draw();
            Loop();

            // ＤＸライブラリの後始末
            DX.DxLib_End();
        }
    }
}
