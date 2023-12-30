using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DxLibDLL;

namespace VisualStudio2015
{
    //処理は秒間50回
    //描画はリフレッシュレートに依存(VSync)
    class Program
    {
        static readonly int TIMER_INTERVAL = 16;
        internal static readonly int FIELD_WIDTH = 8;
        internal static readonly int FIELD_HEIGHT = 15;
        internal static readonly int BLOCK_SIZE = 32;
        static int Timer;
        static int background;
        static int PROCESS;
        static int DRAWING;
        static bool ThreadendFlag = false;


        //3レンブロックの集合体
        static List<Three_Blocks> block_list = new List<Three_Blocks>()
        {

        };

        //フィールド（位置指定）
        static Field field = new Field(500,100); 

        //現在落下中の3連ブロック
        internal static Three_Blocks now_fall = new Three_Blocks(6,100,12);      

        //テスト用ブロック
        static Block block = new Block();


        static void Init()
        {
            DX.SetMultiThreadFlag(DX.TRUE);
            DX.SetMainWindowText("puzzle");//タイトル名
            DX.SetOutApplicationLogValidFlag(DX.FALSE);//ログ非表示
            DX.ChangeWindowMode(DX.TRUE);//ウィンドウモードにする
            DX.SetGraphMode(1280, 720, 32); //ウィンドウサイズと色ビットの調整 
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);//裏画面設定
            DX.SetAlwaysRunFlag(DX.TRUE);//常に更新
            Timer = DX.GetNowCount(); //計測開始時刻

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
            DRAWING++;
            DX.ClearDrawScreen();

            DX.DrawString(1000, 500, "処理回数:"+Convert.ToString(PROCESS), DX.GetColor(128, 128, 128));
            DX.DrawString(1000, 516, "描画回数:" + Convert.ToString(DRAWING), DX.GetColor(128, 128, 128));


            field.DrawField();

            //now_fall.DBlocks(2, 2);
            //three_blocks.DBlocks(15, 15);
            //DX.DrawGraph(62, 62, background, DX.FALSE);

            now_fall.DBlocks();
            //Debug.WriteLine(block_list.Count);

            //now_fall.DBlocks(2, 2);

            DX.WaitVSync(1);
            DX.ScreenFlip();
        }
        static void Update()
        {
            PROCESS ++;
            if (now_fall.Fall())
            {
                field.LoadField();
                block_list.Add(now_fall);
                now_fall = new Three_Blocks(6.5, 35, 15);

            }

            now_fall.Key();




        }

        static void Loop()
        {
            while (!ThreadendFlag)
            {
                DX.WaitTimer(20);
                Update();
                Timer += TIMER_INTERVAL;
  
            }                          
        }

        static void Refresh()
        {

        }

    
        static void Main()//メイン関数
        {
            //初期化
            Init();

            //画像読み込み
            Load();

            //スレッド作成、実行
            Thread t = new Thread(new ThreadStart(Loop));
            t.Start();
            
            // メインループ
            while (DX.ProcessMessage() != -1)
            {
                Draw();
            }

            //スレッド終了
            ThreadendFlag = true;

            // ＤＸライブラリの後始末
            DX.DxLib_End();
        }
    }
}
