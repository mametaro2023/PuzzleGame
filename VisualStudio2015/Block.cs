using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudio2015
{
    public class Block
    {
        protected static int[] blocks = new int[6];//ブロックの種類

        public void LBlocks()//ブロックの読み込み
        {
            for (int i = 0; i < 6; i++)
            {
                Debug.WriteLine("Images\\blocks\\block" + i + ".png");
                blocks[i] = DX.LoadGraph("Images\\blocks\\block" + i + ".png");
                
            }

        }

        public void DBlocks(int begin_X, int Begin_Y, byte block_id)//ブロックの描画、block_idはブロック番号
        {
            DX.DrawExtendGraph(begin_X, Begin_Y, begin_X + 32, Begin_Y + 32, blocks[block_id], DX.FALSE);
        }
    }
}
