using System.Collections.Generic;
using lab9.consoler;
using lab9.interfaces;

namespace lab9.classes
{
    public class Checkpoint
    {
        public List<IVisitor> VisitorsWantToISIT = new();
        public List<IVisitor> VisitorsCanToISIT = new();

        public uint MasksCount { get; set; }

        public void Check()
        {
            Table table = new();
            
            foreach (var visitor in VisitorsWantToISIT)
            {
                Row row = new();
                row.Cells.Add(new Cell
                {
                    Text = visitor.Name,
                    FixedWidth = 20,
                    WidthMode = Cell.WidthModeEnum.Fixed
                });
                
                row.Cells.Add(new Cell
                {
                    Text = visitor.GetType().Name,
                    FixedWidth = 15,
                    WidthMode = Cell.WidthModeEnum.Fixed,
                    TextAlign = Cell.TextAlignEnum.Center
                });
                
                if (visitor is not (ICanPutOnMask and ICanHaveQR and ICanDisinfectHand))
                {
                    row.Cells.Add(new Cell
                    {
                        Text = "Не проходит по формальным признакам!",
                    });
                    table.Rows.Add(row);
                    continue;
                }

                if (visitor is ICanHaveQR {IsHaveQR: false})
                {
                    row.Cells.Add(new Cell
                    {
                        Text = "Не имеет qr!"
                    });
                    table.Rows.Add(row);
                    continue;
                }

                if (visitor is ICanPutOnMask {IsHaveMask: true})
                {
                    row.Cells.Add(new Cell()
                    {
                        Text = "Допущен на занятия :)"
                    });
                    table.Rows.Add(row);

                    VisitorsCanToISIT.Add(visitor);
                    
                    continue;
                }

                if (MasksCount == 0)
                {
                    row.Cells.Add(new Cell
                    {
                        Text = "Не хватило масок!"
                    });
                    table.Rows.Add(row);
                    continue;
                }

                MasksCount--;
                
                row.Cells.Add(new Cell()
                {
                    Text = "Допущен на занятия (с нашей маской) :)"
                });
                table.Rows.Add(row);

                VisitorsCanToISIT.Add(visitor);
            }

            foreach (var visitor in VisitorsCanToISIT)
            {
                VisitorsWantToISIT.Remove(visitor);
            }
            
            Consoler.PrintTable(table);
        }
    }
}