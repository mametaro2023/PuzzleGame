using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudio2015
{
    public class Three_Blocks: Block
    {
        static Random rand = new Random();
        static int[] tblocks = new int[3];
        static Point pos = new Point();
        static int Vec1; //3レンブロックの落下速度

        public Three_Blocks(int FallSpeed)//ブロックの初期設定
        {
            Vec1 = FallSpeed;//落下速度
        }


        public void GenerateBlock()
        {
            for (int i = 0; i < 3; i++)
            {
                tblocks[i] = rand.Next(6);
            }
        }

        public void DBlocks(int begin_X, int Begin_Y)
        {
            for (int i = 0; i < tblocks.Length; i++)
            {
                DX.DrawExtendGraph (pos.X + begin_X ,
                                    pos.Y + Begin_Y + 32 * i,
                                    pos.X + begin_X + 32,
                                    pos.Y + Begin_Y + 32 * (i + 1),
                                    blocks[tblocks[i]],
                                    DX.TRUE);
            }
        }


        public void Fall()
        {
            pos.Y += Vec1;
        }


    }
}
