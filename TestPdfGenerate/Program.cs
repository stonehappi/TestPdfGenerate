// See https://aka.ms/new-console-template for more information

using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

const string logoBase64 =
    "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";
var logo = new StreamContent(new MemoryStream(Convert.FromBase64String(logoBase64)));
var logoSize = 80.0f;
var mx = 40.0f;
var my = 55.0f;
var width = PageSizes.A4.Width - (2 * mx);
QuestPDF.Settings.License = LicenseType.Community;
FontManager.RegisterFont(File.OpenRead("/Users/stone-wh/Wedding-Hub/ATS/TestPdfGenerate/TestPdfGenerate/Dangrek-Regular.ttf"));
FontManager.RegisterFont(File.OpenRead("/Users/stone-wh/Wedding-Hub/ATS/TestPdfGenerate/TestPdfGenerate/Moul-Regular.ttf"));
Document.Create(container =>
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.MarginHorizontal(mx);
            page.MarginVertical(my);
            page.DefaultTextStyle(x => x
                .FontFamily("Dangrek")
                .FontSize(14)
            );

            page.Header()
                .Row(row =>
                {
                    row.ConstantItem(logoSize)
                        .Image(logo.ReadAsStream());
                    row.RelativeItem()
                        .DefaultTextStyle(d => d.FontFamily("Times"))
                        .Column(col =>
                        {
                            col.Item()
                                .Background(Colors.Green.Lighten3)
                                .PaddingVertical(4)
                                .AlignCenter()
                                .DefaultTextStyle(d => d.Bold().FontSize(20))
                                .Row(rowBrand =>
                                {
                                    rowBrand.AutoItem()
                                        .Text("D")
                                        .FontColor(Colors.Red.Medium);
                                    rowBrand.AutoItem()
                                        .Text("YNAMIC");
                                    rowBrand.AutoItem()
                                        .PaddingLeft(4)
                                        .Text("E")
                                        .FontColor(Colors.Blue.Medium);
                                    rowBrand.AutoItem()
                                        .Text("NGINEERING");
                                    rowBrand.AutoItem()
                                        .PaddingLeft(4)
                                        .Text("S")
                                        .FontColor(Colors.White);
                                    rowBrand.AutoItem()
                                        .Text("TEELS");
                                });
                            col.Spacing(4);
                            col.Item()
                                .Text(
                                    "N\u00b0 966, st. 2011, Sangkat Kakab, Khan Pou Senchey, Phnom Penh, 061/98 22 31 41")
                                .FontSize(10)
                                .AlignCenter()
                                ;
                        });
                });

            page.Content()
                .PaddingVertical(20)
                .Column(x =>
                {
                    x.Item()
                        .Background(Colors.Blue.Darken3)
                        .PaddingVertical(12)
                        .AlignCenter()
                        .Text("ប្រាក់ខែបុគ្គលិក")
                        .FontFamily("Moul")
                        .FontSize(20)
                        .FontColor(Colors.White);
                    x.Spacing(20);
                    x.Item()
                        .Row(row =>
                        {
                            row
                                .ConstantItem(logoSize + 12)
                                .Column(col =>
                                {
                                    col.Item()
                                        .Text("ឈ្មោះបុគ្គលិក");
                                    col.Spacing(8);
                                    col.Item()
                                        .Text("ទួនាទី");
                                    col.Spacing(8);
                                    col.Item()
                                        .Text("ប្រាក់ខែ");
                                });
                            row
                                .RelativeItem()
                                .Column(col =>
                                {
                                    col.Item()
                                        .Text("៖ ឈ្មោះបុគ្គលិក");
                                    col.Spacing(8);
                                    col.Item()
                                        .Text("៖ ទួនាទី");
                                    col.Spacing(8);
                                    col.Item()
                                        .Text("៖ ប្រាក់ខែ");
                                });
                            row
                                .ConstantItem(80)
                                .Column(col =>
                                {
                                    col.Item()
                                        .Text("កម្រៃប្រចាំខៃ");
                                    col.Spacing(8);
                                    col.Item()
                                        .Text("អត្រាប្រាក់");
                                    col.Spacing(8);
                                    col.Item();
                                });
                            row
                                .ConstantItem(70)
                                .Column(col =>
                                {
                                    col.Item()
                                        .DefaultTextStyle(d => d.FontColor(Colors.Red.Medium))
                                        .Background(Colors.Grey.Medium)
                                        .Row(r =>
                                        {
                                            r.AutoItem()
                                                .AlignLeft()
                                                .Text("៖ $");
                                            r.RelativeItem()
                                                .AlignRight()
                                                .Text("100.00");
                                        });
                                    col.Spacing(8);
                                    col.Item()
                                        .Text("៖ 4000 r/1$");
                                    col.Spacing(8);
                                    col.Item();
                                });
                        });
                    x.Item()
                        .Border(0.5f)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.ConstantColumn(logoSize + 12);
                                c.RelativeColumn();
                                c.ConstantColumn(80);
                                c.ConstantColumn(70);
                            });
                            table.Header(th =>
                            {
                                th.Cell().Border(0.5f).Background(Colors.LightBlue.Medium).Text("No").AlignCenter();
                                th.Cell().Border(0.5f).Background(Colors.LightBlue.Medium).Text("Des").AlignCenter();
                                th.Cell().Border(0.5f).Background(Colors.LightBlue.Medium).Text("Unit").AlignCenter();
                                th.Cell().Border(0.5f).Background(Colors.LightBlue.Medium).Text("Amount").AlignCenter();
                            });
                            for (int i = 0; i < 6; i++)
                            {
                                table.Cell().Border(0.5f).PaddingVertical(2).Text("1").AlignCenter();
                                table.Cell().Border(0.5f).PaddingVertical(2).PaddingHorizontal(4).Text("item 1");
                                table.Cell().Border(0.5f).PaddingVertical(2).Text("Unit 1").AlignCenter();
                                table.Cell().Border(0.5f).PaddingVertical(2).Text("Amount 1");
                            }
                            
                        });
                    
                    x.Item()
                        .Border(0.5f)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn();
                                c.ConstantColumn(70);
                            });
                            
                            for (int i = 0; i < 7; i++)
                            {
                                table.Cell().Border(0.5f).PaddingVertical(2).PaddingHorizontal(4).Text("1");
                                table.Cell().Border(0.5f).PaddingVertical(2).Text("Amount 1").AlignCenter();
                            }
                            table.Footer(ft =>
                            {
                                ft.Cell().Border(0.5f).Background(Colors.Red.Lighten1).PaddingHorizontal(4).Text("No");
                                ft.Cell().Border(0.5f).Background(Colors.Red.Lighten1).Text("Des").AlignCenter();
                            });
                        });
                });

            page.Footer()
                .AlignCenter()
                .Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                });
        });
    })
    .GeneratePdf("/Users/stone-wh/Desktop/output.pdf");