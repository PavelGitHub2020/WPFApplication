   M S B A M L   `   `   `  ????C  ?TestTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TestTaskTestTask  5   	       TestTask.MainForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TestTask     5   	     ? Title$  MainForm??5   	   $	??400??6   $	??500??6'    ? WindowStartupLocation$ CenterScreen=?63   .??5	      ? .+?5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid??5
      $	??350??6&   $	??170??63   $??-300,10,0,0q?6?      
IsReadOnly .    SelectionMode$ Single=?5      ??6*   ?? *
SomeValues+ ?? SelectedItem 6M   ?? *SelectedSomeValue+?? 5   
   $??-100,140,0,0q?6   $	??100??6+   $??90??67   $y?Hidden=?6m    ? DataContext 6C   ?? *SelectedSomeValue+.+?5      ?? $??Selected item??6   ?? 5      $
??Name??6   ?? 5      -   5         ??Name$ txtName??5       ?? TextAlignment$ Center=?5      ??5   '   ?? *Name+	 ?? UpdateSourceTrigger$	 PropertyChanged=?5      ?? 5      $??Value??6   ?? 5      -   5        $ txtValue??5      ??6(   ?? *SValue+$	 PropertyChanged=?5        5   
   -   5        $ 	dataGrid1??5      $	??135??6&   $	??350??62   $??
340,10,0,0q?6?    . 6g   ?? 5   
   $	??140??6   $??30??6    $??40,-320,0,0q?6,   $??20(?6A   Selected values:6a   ?? 5   
   -   5        
 ??Name$
 textName??5      $??97??6&   $??40??61   $??-95,-240,0,0q?6=   $
??Wrap=?6S   6i   ?? 5   
   -   5        $
 	textValue??5      $??34??6'   $??40??62   $??155,-240,0,0q?6>   $
??Wrap=?6T   6j   ?? 5   
   -   5         ??Name$ btnMatrixOfResult??5      $	??140??6,   $??30??68   $??40,-180,0,0q?6D   $??20(?6Y   .??5   .   Matrix of result:6A   ?? 5!   
   $??30??6   $??20??6   $??-70,-120,0,0q?6+   Cells:6I   ?? 5#   
   $??30??6   $??20??6   $??150,-120,0,0q?6+   Value:6I   ?? 5%   
   -   5        $
 resultValue??5%      $??50??6)   $??20??64   $??170,-80,0,0q?6@   6W   ?? 5'   
   -	   5        $
 
resultName??5'      $??50??6(   $??20??63   $??-50,-80,0,0q?6?   6W   5(      5)      