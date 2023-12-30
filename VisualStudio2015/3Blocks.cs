using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VisualStudio2015
{
    internal class Three_Blocks: Block
    {
        private Random rand = new Random();
        internal byte[] tblocks = new byte[3];
        internal Point pos = new Point(); //開始位置からの相対位置
        private Point begin_pos = new Point(); // 開始位置
        private double Vec1; //3レンブロックの落下速度
        private int KEY_LEFT = 0;
        private int KEY_RIGHT = 0;
        private int KEY_UP = 0;
        private byte tempblock;
        private double realposY ;
        //bool isFalled = false;

        internal Three_Blocks(double FallSpeed, int Begin_X, int Begin_Y)//ブロックの初期設定
        {
            Vec1 = FallSpeed;//落下速度
            begin_pos.X = Begin_X;
            begin_pos.Y = Begin_Y;
            GenerateBlock();
        }


        private void GenerateBlock()
        {
            for (int i = 0; i < 3; i++)
            {
                tblocks[i] = (byte)rand.Next(6);
            }
        }

        internal void DBlocks()
        {
            for (int i = 0; i < tblocks.Length; i++) 
            {
                DX.DrawExtendGraph (begin_pos.X + pos.X,
                                    begin_pos.Y + pos.Y + 32 * i,
                                    begin_pos.X + pos.X + 32,
                                    begin_pos.Y + pos.Y + 32 * (i + 1),
                                    blocks[tblocks[i]],
                                    DX.FALSE);

            }
        }


        internal bool Fall()
        {

            if (pos.Y < Program.FIELD_HEIGHT * (Program.BLOCK_SIZE - 1))
            {
                realposY += Vec1;
                pos.Y = (int)realposY;
                return false;

            }
            else
            {
                pos.Y = Program.FIELD_HEIGHT * (Program.BLOCK_SIZE - 1);
                return true;

            }
            
            
        }

        internal void Key()
        {
            if (DX.CheckHitKey(DX.KEY_INPUT_RIGHT) == 1) KEY_RIGHT++;
            else KEY_RIGHT = 0;

            if (DX.CheckHitKey(DX.KEY_INPUT_LEFT) == 1) KEY_LEFT++;
            else KEY_LEFT = 0;

            if (DX.CheckHitKey(DX.KEY_INPUT_UP) == 1) KEY_UP++;
            else KEY_UP = 0;


            if ((KEY_RIGHT == 1 || KEY_RIGHT > 13) && Program.now_fall.pos.X / Program.BLOCK_SIZE < Program.FIELD_WIDTH - 1)
            {
                DX.WaitTimer(20);
                pos.X += Program.BLOCK_SIZE;
            }
            if ((KEY_LEFT == 1 || KEY_LEFT > 13) && Program.now_fall.pos.X / Program.BLOCK_SIZE > 0)
            {
                DX.WaitTimer(20);
                pos.X -= Program.BLOCK_SIZE;
            }

            if (KEY_UP == 1)
            {
                tempblock = tblocks[2];
                tblocks[2] = tblocks[1];
                tblocks[1] = tblocks[0];
                tblocks[0] = tempblock;

            }



        }



    }
}
