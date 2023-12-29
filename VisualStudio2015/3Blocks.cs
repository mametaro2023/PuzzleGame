using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudio2015
{
    public class Three_Blocks: Block
    {
        static Random rand = new Random();
        static int[] tblocks = new int[3];
        static int x, y; //3レンブロックの位置
        static int v; //3レンブロックの落下速度



        public void DBlocks(int begin_X, int Begin_Y)
        {
            for (int i = 0; i < tblocks.Length; i++)
            {
                tblocks[i] = rand.Next(6);
                DX.DrawExtendGraph (begin_X ,
                                    Begin_Y +32 * i,
                                    begin_X + 32,
                                    Begin_Y + 32 * (i + 1),
                                    blocks[tblocks[i]],
                                    DX.FALSE);
            }
        }


    }
}
