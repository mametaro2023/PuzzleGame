using DxLibDLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudio2015
{
    internal class Field
    {
        private byte[,] field = new byte[Program.FIELD_WIDTH, Program.FIELD_HEIGHT + 5];
        private int width = Program.FIELD_WIDTH;
        private int height = Program.FIELD_HEIGHT;
        private Point pos = new Point(); //フィールドの位置

        internal Field(int Begin_X, int Begin_Y) {
            pos.X = Begin_X;
            pos.Y = Begin_Y;
        }
        


        internal void LoadField()
        {

            for(int i = 0; i < 3; i++)
            {
                //Debug.WriteLine(Program.now_fall.pos.X / Program.BLOCK_SIZE );
                //Debug.WriteLine(Program.now_fall.pos.Y / Program.BLOCK_SIZE );
                field[
                    Program.now_fall.pos.X / Program.BLOCK_SIZE, 
                    Program.now_fall.pos.Y / Program.BLOCK_SIZE + 3 + i 
                    ] = Program.now_fall.tblocks[i];
            }
        }

        internal void DrawField()
        {
            for (int i = 0;i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    DX.DrawExtendGraph(pos.X + 32 * i,
                                    pos.Y + 32 * j,
                                    pos.X + 32 * (i + 1),
                                    pos.Y + 32 * (j + 1),
                                    Block.blocks[field[i,j + 5]],
                                    DX.TRUE);
                }
            }
        }

        
    }



    
}
