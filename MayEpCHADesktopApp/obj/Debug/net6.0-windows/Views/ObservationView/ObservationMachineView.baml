   M S B A M L   `   `   `  ????M  IMayEpCHADesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:MayEpCHADesktopApp.Resources.Components'MayEpCHADesktopApp.Resources.Components  5      R NMayEpCHADesktopApp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?Uclr-namespace:MayEpCHADesktopApp.Core.ValueConverter;assembly=MayEpCHADesktopApp.Core&MayEpCHADesktopApp.Core.ValueConverter 5
      E    ?MayEpCHADesktopApp.Views.ObservationView.ObservationMachineView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      L
components5clr-namespace:MayEpCHADesktopApp.Resources.Components     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5      _	 [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes 	 5	      e	ConverterUclr-namespace:MayEpCHADesktopApp.Core.ValueConverter;assembly=MayEpCHADesktopApp.Core 	 5
      -   5          >?Name$  UObservation??5         MaterialDesignBody#???   5      $??Regular"?5      $??13(?5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper#???  5        MaterialDesignFont#???  5      $	??824??5      $??1267.2??5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??2* ?6   ?? 5      $??4* ?6   .+?5   
   # 	 MaterialDesignThemes.Wpf.Card  $??7 10 7 5q?6   $??0??60   .??5      ?  5"      ?? 5#      ?? 5$      .+?5&      ? $??0??6    ? ColumnDefinitions 5'      ?? 5(      ?? 5)      ?? 5*      ?? 5+      ?? 5,      ?? 5-      ?? 5.      ?? 5/      ?? 50      ?? 51      ?? 52      ?? 53      ?? 54      ?? 55      .+?58      ? $??0??6   .+?59      4   .MayEpCHADesktopApp.Resources.Components.MayNho  $
??5 10q?6,      MachineNames$	 M28??5:   ,      CodeMachine$
 SM50??5;   ,      StatusBackground 5<   !   ?? *Status+ ?? 	Converter @  :MayEpCHADesktopApp.Core.ValueConverter.IntToColorConverter  	 ? DataContext	 5=   ,   ?? *M28+5@      ?? 5A      ???	#004899EA???	#004899EA???	#00F9FEF9*  $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 5B      +  %Microsoft.Xaml.Behaviors.EventTrigger  5C   "      	EventName$ MouseDoubleClick??61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5D   &   -  'Prism.Interactivity.InvokeCommandAction     Command 6@   ?? *SwitchPage1+5E   #   5G      5H      ? 5I      $??1??6   .+?5J        $
??5 10q?6,   $	 M26??5K   ,   $
 MA90??5L   ,    5M   !   ?? *Status+   	 5N   ,   ?? *M26+
 5O        5P   "   $ LeftMouseDown??61   . 5Q   &      6@   ?? *SwitchPage1+5R   #   5T      ?? 5U      ???	#004899EA???	#004899EA???	#00F9FEF9
 5V        5W   "   $ MouseDoubleClick??61   . 5X   &      6@   ?? *SwitchPage1+5Y   #   5[      5\      ? 5]      $??2??6   .+?5^        $
??5 10q?6,   $	 M24??5_   ,   $ MA120??5`   ,    5a   !   ?? *Status+   	 5b   ,   ?? *M24+
 5c        5d   "   $ LeftMouseDown??61   . 5e   &      6@   ?? *SwitchPage1+5f   #   5h      ?? 5i      ???	#004899EA???	#004899EA???	#00F9FEF9
 5j        5k   "   $ MouseDoubleClick??61   . 5l   &      6@   ?? *SwitchPage1+5m   #   5o      5p      ? 5q      $??3??6   .+?5r        $
??5 10q?6,   $	 M22??5s   ,   $
 MA90??5t   ,    5u   !   ?? *Status+   	 5v   ,   ?? *M22+
 5w        5x   "   $ LeftMouseDown??61   . 5y   &      6@   ?? *SwitchPage2+5z   #   5|      ?? 5}      ???	#004899EA???	#004899EA???	#00F9FEF9
 5~        5   "   $ MouseDoubleClick??61   . 5?   &      6@   ?? *SwitchPage2+5?   #   5?      5?      ? 5?      $??4??6   .+?5?        $
??5 10q?6,   $	 M20??5?   ,   $ MA160??5?   ,    5?   !   ?? *Status+   	 5?   ,   ?? *M20+
 5?        5?   "   $ LeftMouseDown??61   . 5?   &      6@   ?? *SwitchPage1+5?   #   5?      ?? 5?      ???	#004899EA???	#004899EA???	#00F9FEF9
 5?        5?   "   $ MouseDoubleClick??61   . 5?   &      6@   ?? *SwitchPage1+5?   #   5?      5?      ? 5?      $??5??6   .+?5?        4	   .MayEpCHADesktopApp.Resources.Components.MayNho 	  Loaded$ MayNho_Loaded_2??5?   @   $
??5 10q?5?   ,   $	 M18??5?   ,   $ MA160??5?   ,   	 5?   ,   ?? *M18+ 5?   !   ?? *Status+   
 5?        5?   "   $ LeftMouseDown??61   . 5?   &      6@   ?? *SwitchPage2+5?   #   5?      ?? 5?      ???	#004899EA???	#004899EA???	#00F9FEF9
 5?        5?   "   $ MouseDoubleClick??61   . 5?   &      6@   ?? *SwitchPage2+5?   #   5?      5?      ? 5?      $??6??6   .+?5?        $
??5 10q?6,   $	 M16??5?   ,   $ MA160??5?   ,    5?   !   ?? *Status+   	 5?   ,   ?? *M16+
 5?        5?   "   $ LeftMouseDown??61   . 5?   &      6@   ?? *SwitchPage3+5?   #   5?      ?? 5?      ???	#004899EA???	#004899EA???	#00F9FEF9
 5?        5?   "   $ MouseDoubleClick??61   . 5?   &      6@   ?? *SwitchPage3+5?   #   5?      5?      ? 5?      $??7??6   .+?5?        $
??5 10q?6,   $
 MM14??5?   ,   $ MA160??5?   ,    5?   !   ?? *Status+   	 5?   ,   ?? *M14+
 5?        5?   "   $ LeftMouseDown??61   . 5?   &      6@   ?? *SwitchPage3+5?   #   5?      ?? 5?      ???	#004899EA???	#004899EA???	#00F9FEF9
 5?        5?   "   $ MouseDoubleClick??61   . 5?   &      6@   ?? *SwitchPage3+5?   #   5?      5?      ? 5?      $??8??6   .+?5?        $
??5 10q?6,   $	 M12??5?   ,   $ MA160??5?   ,    5?   !   ?? *Status+   	 5?   ,   ?? *M12+
 5?        5?   "   $ LeftMouseDown??61   . 5?   &      6@   ?? *SwitchPage3+5?   #   5?      ?? 5?      ???	#004899EA???	#004899EA???	#00F9FEF9
 5?        5?   "   $ MouseDoubleClick??61   . 5?   &      6@   ?? *SwitchPage3+5?   #   5?      5?      ? 5?      $??9??6   .+?5?        $
??5 10q?6,   $	 M10??5?   ,   $ MA160??5?   ,   	 5?   ,   ?? *M10+ 5?   !   ?? *Status+   
 5?        5?   "   $ LeftMouseDown??61   . 5?   &      6@   ?? *Page1+5?   #   5?      ?? 5?      ???	#004899EA???	#004899EA???	#00F9FEF9
 5?        5?   "   $ MouseDoubleClick??61   . 5?   &      6@   ?? *SwitchPage1+5?   #   5?      5?      ? 5?      $??10??6   .+?5?        $
??5 10q?6,   $ M8??5?   ,   $ MA160??5  ,    5   !   ?? *Status+   	 5  ,   ?? *M8+
 5       5  "   $ LeftMouseDown??61   . 5  &      6@   ?? *Page1+5  #   5     ?? 5	     ???	#004899EA???	#004899EA???	#00F9FEF9
 5
       5  "   $ MouseDoubleClick??61   . 5  &      6@   ?? *SwitchPage1+5  #   5     5     ? 5     $??11??6   .+?5       $
??5 10q?6,   $ M6??5  ,   $ MA120??5  ,    5  ,   ?? *Status+   	 5  ,   ?? *M6+
 5       5  "   $ LeftMouseDown??61   . 5  &      6@   ?? *Page1+5  #   5     ?? 5     ???	#004899EA???	#004899EA???	#00F9FEF9
 5       5  "   $ MouseDoubleClick??61   . 5   &      6@   ?? *SwitchPage1+5!  #   5#     5$     ? 5%     $??12??6   .+?5&       $
??5 10q?6,   $ M4??5(  ,   $
 ZE90??5*  ,    5'  !   ?? *Status+   	 5)  ,   ?? *M4+
 5+       5,  "   $ LeftMouseDown??61   . 5-  &      6@   ?? *SwitchPage5+5.  #   50     ?? 51     ???	#004899EA???	#004899EA???	#00F9FEF9
 52       53  "   $ MouseDoubleClick??61   . 54  &      6@   ?? *SwitchPage5+55  #   57     58     ? 59     $??13??6   .+?5:       $
??5 10q?6,   $ M2??5;  ,   $ 200ES??5>  ,    5<  !   ?? *Status+   	 5=  ,   ?? *M2+
 5?       5@  "   $ LeftMouseDown??61   . 5A  &      6@   ?? *SwitchPage5+5B  #   5D     ?? 5E     ???	#004899EA???	#004899EA???	#00F9FEF9
 5F       5G  "   $ MouseDoubleClick??61   . 5H  &      6@   ?? *SwitchPage5+5I  #   5K     5L     5M     ? 5N     $??1??6    5O     ?? 5P     ?? 5Q     ?? 5R     ?? 5S     ?? 5T     ?? 5U     ?? 5V     ?? 5W     ?? 5X     ?? 5Y     ?? 5Z     ?? 5[     ?? 5\     ?? 5]     .+?5`     ? $??0??6   .+?5a       $ MayNho_Loaded??5f  >   $
??5 10q?5a  ,   $	 M27??5b  ,   $ 250ES??5c  ,      NoteMachine$	 TMC??5f  ,    5d  !   ?? *Status+   	 5e  ,   ?? *M27+
 5g       5h  "   $ LeftMouseDown??61   . 5i  &      6@   ?? *SwitchPage1+5j  #   5l     ?? 5m     ???	#004899EA???	#004899EA???	#00F9FEF9
 5n       5o  "   $ MouseDoubleClick??61   . 5p  &      6@   ?? *SwitchPage1+5q  #   5s     5t     ? 5u     $??1??6   .+?5v       $
??5 10q?6,   $	 M25??5w  ,   $
 MA90??5z  ,    5x  !   ?? *Status+   	 5y  ,   ?? *M25+
 5{       5|  "   $ LeftMouseDown??61   . 5}  &      6@   ?? *SwitchPage1+5~  #   5?     ?? 5?     ???	#004899EA???	#004899EA???	#00F9FEF9
 5?       5?  "   $ MouseDoubleClick??61   . 5?  &      6@   ?? *SwitchPage1+5?  #   5?     5?     ? 5?     $??2??6   .+?5?       $
??5 10q?6,   $	 M23??5?  ,   $ MA120??5?  ,    5?  !   ?? *Status+   	 5?  ,   ?? *M23+
 5?       5?  "   $ LeftMouseDown??61   . 5?  &      6@   ?? *SwitchPage1+5?  #   5?     ?? 5?     ???	#004899EA???	#004899EA???	#00F9FEF9
 5?       5?  "   $ MouseDoubleClick??61   . 5?  &      6@   ?? *SwitchPage1+5?  #   5?     5?     ? 5?     $??3??6   .+?5?       $
??5 10q?6,   $	 M21??5?  ,   $ MA160??5?  ,    5?  !   ?? *Status+   	 5?  ,   ?? *M21+
 5?       5?  "   $ LeftMouseDown??61   . 5?  &      6@   ?? *SwitchPage2+5?  #   5?     ?? 5?     ???	#004899EA???	#004899EA???	#00F9FEF9
 5?       5?  "   $ MouseDoubleClick??61   . 5?  &      6@   ?? *SwitchPage2+5?  #   5?     5?     ? 5?     $??4??6   .+?5?       $ MayNho_Loaded_1??5?  @   $
??5 10q?5?  ,   $	 M19??5?  ,   $ MA160??5?  ,    5?  !   ?? *Status+   	 5?  ,   ?? *M19+
 5?       5?  "   $ LeftMouseDown??61   . 5?  &      6@   ?? *SwitchPage2+5?  #   5?     ?? 5?     ???	#004899EA???	#004899EA???	#00F9FEF9
 5?       5?  "   $ MouseDoubleClick??61   . 5?  &      6@   ?? *SwitchPage2+5?  #   5?     5?     ? 5?     $??5??6   .+?5?       $
??5 10q?6,   $	 M17??5?  ,   $ MA160??5?  ,    5?  !   ?? *Status+   	 5?  ,   ?? *M17+
 5?       5?  "   $ LeftMouseDown??61   . 5?  &      6@   ?? *SwitchPage2+5?  #   5?     ?? 5?     ???	#004899EA???	#004899EA???	#00F9FEF9
 5?       5?  "   $ MouseDoubleClick??61   . 5?  &      6@   ?? *SwitchPage2+5?  #   5?     5?     ? 5?     $??6??6   .+?5?       $
??5 10q?6,   $	 M15??5?  ,   $ MA250??5?  ,    5?  !   ?? *Status+   	 5?  ,   ?? *M15+
 5?       5?  "   $ LeftMouseDown??61   . 5?  &      6@   ?? *SwitchPage3+5?  #   5?     ?? 5?     ???	#004899EA???	#004899EA???	#00F9FEF9
 5?       5?  "   $ MouseDoubleClick??61   . 5?  &      6@   ?? *SwitchPage3+5?  #   5?     5?     ? 5?     $??7??6   .+?5?       $
??5 10q?6,   $	 M13??5?  ,   $ MA250??5?  ,    5?  !   ?? *Status+   	 5?  ,   ?? *M13+
 5?       5?  "   $ LeftMouseDown??61   . 5?  &      6@   ?? *SwitchPage3+5?  #   5?     ?? 5?     ???	#004899EA???	#004899EA???	#00F9FEF9
 5?       5?  "   $ MouseDoubleClick??61   . 5?  &      6@   ?? *SwitchPage3+5?  #   5?     5      ? 5     $??8??6   .+?5       $
??5 10q?6,   $	 M11??5  ,   $ MA250??5  ,    5  !   ?? *Status+   	 5  ,   ?? *M11+5     ?? 5	     ???	#004899EA???	#004899EA???	#00F9FEF9
 5
       5  "   $ MouseDoubleClick??61   . 5  &      6@   ?? *SwitchPage3+5  #   5     5     ? 5     $??9??6   .+?5       $
??5 10q?6,   $ M9??5  ,   $ MA250??5  ,    5  !   ?? *Status+   	 5  ,   ?? *M9+
 5       5  "   $ LeftMouseDown??61   . 5  &      6@   ?? *SwitchPage4+5  #   5     ?? 5     ???	#004899EA???	#004899EA???	#00F9FEF9
 5       5  "   $ MouseDoubleClick??61   . 5   &      6@   ?? *SwitchPage4+5!  #   5#     5$     ? 5%     $??10??6   .+?5&       $
??5 10q?6,   $ M7??5'  ,   $ MA250??5*  ,    5(  !   ?? *Status+   	 5)  ,   ?? *M7+
 5+       5,  "   $ LeftMouseDown??61   . 5-  &      6@   ?? *SwitchPage4+5.  #   50     ?? 51     ???	#004899EA???	#004899EA???	#00F9FEF9
 52       53  "   $ MouseDoubleClick??61   . 54  &      6@   ?? *SwitchPage4+55  #   57     58     ? 59     $??11??6   .+?5:       $
??5 10q?6,   $ M5??5<  ,   $ MA120??5>  ,    5;  !   ?? *Status+   	 5=  ,   ?? *M5+
 5?       5@  "   $ LeftMouseDown??61   . 5A  &      6@   ?? *SwitchPage4+5B  #   5D     ?? 5E     ???	#004899EA???	#004899EA???	#00F9FEF9
 5F       5G  "   $ MouseDoubleClick??61   . 5H  &      6@   ?? *SwitchPage4+5I  #   5K     5L     ? 5M     $??12??6   .+?5N       $
??5 10q?6,   $ M3??5O  ,   $
 ZE90??5R  ,    5P  !   ?? *Status+   	 5Q  ,   ?? *M3+
 5S       5T  "   $ LeftMouseDown??61   . 5U  &      6@   ?? *SwitchPage5+5V  #   5X     ?? 5Y     ???	#004899EA???	#004899EA???	#00F9FEF9
 5Z       5[  "   $ MouseDoubleClick??61   . 5\  &      6@   ?? *SwitchPage5+5]  #   5_     5`     ? 5a     $??13??6   .+?5b       $
??5 10q?6,   $ M1??5c  ,   $
 12ST??5e  ,   $	 CLF??5g  ,    5d  !   ?? *Status+   	 5f  ,   ?? *M1+
 5h       5i  "   $ LeftMouseDown??61   . 5j  &      6@   ?? *SwitchPage5+5k  #   5m     ?? 5n     ???	#004899EA???	#004899EA???	#00F9FEF9
 5o       5p  "   $ MouseDoubleClick??61   . 5q  &      6@   ?? *SwitchPage5+5r  #   5t     5u     5v     5w     5x       5y  
   $??1??6   $
??Left=?5{     $	??7 5q?5|     ??5z     ??  ?? ElementName$ UObservation?? ?? Path$ ActualWidth? :
  4MayEpCHADesktopApp.Core.ValueConverter.SizeConverter
   ?? ConverterParameter$	 0.6??.??5}     ? .+?5?     ?? .??5?     ?? .+?5?     ?  5?     ?? 5?  "   ?? 5?  "   .+?5?     ? $??0??6#   $??
120 5 50 5q?5?  #   $	??230??5?  #   .+?5?  "     $ L6??5?  %   $ CF 800T??5?  %   	 5?  %   ?? *ML6+ 5?  %   ?? *Status+   
 5?  &     5?  *   $ LeftMouseDown??69   . 5?  .      6H   ?? *SwitchPage5+5?  +   5?  #   ?? 5?  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5?  &     5?  *   $ MouseDoubleClick??69   . 5?  .      6H   ?? *SwitchPage5+5?  +   5?  #   5?     ? 5?     $??1??6#   $??
50 5 120 5q?63   $	??230??5?  #   .+?5?  "     $ L5??5?  %   $ 	MALL 1000??5?  %    5?     ?? *Status+   	 5?  %   ?? *ML5+
 5?  &     5?  *   $ LeftMouseDown??69   . 5?  .      6H   ?? *SwitchPage5+5?  +   5?  #   ?? 5?  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5?  &     5?  *   $ MouseDoubleClick??69   . 5?  .      6H   ?? *SwitchPage5+5?  +   5?  #   5?     5?     ? 5?      5?     ?? 5?  "   ?? 5?  "   .+?5?     ? $??0??6#   $??
120 5 50 5q?63   $	??230??5?  #   .+?5?  "     $ L7??5?  %   $ JM 600-C??5?  ,    5?     ?? *Status+   	 5?  %   ?? *ML7+
 5?  &     5?  *   $ LeftMouseDown??69   . 5?  .      6H   ?? *SwitchPage6+5?  +   5?  #   ?? 5?  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5?  &     5?  *   $ MouseDoubleClick??69   . 5?  .      6H   ?? *SwitchPage6+5?  +   5?  #   5?     ? 5?     $??1??6#   $??
50 5 120 5q?63   $	??230??5?  #   .+?5?  "     $ L4??5?  %   $ MALL 800??5?  ,    5?     ?? *Status+   	 5?  %   ?? *ML4+
 5?  &     5?  *   $ LeftMouseDown??69   . 5?  .      6H   ?? *SwitchPage6+5?  +   5?  #   ?? 5?  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5?  &     5?  *   $ MouseDoubleClick??69   . 5?  .      6H   ?? *SwitchPage6+5?  +   5?  #   5?     5?     ? 5?      5?     ?? 5?  "   ?? 5?  "   .+?5?     ? $??0??6#   $??
120 5 50 5q?63   $	??230??5?  #   .+?5?  "     $ L8??5?  %   $ HC 800??5?  ,   	 5?  %   ?? *ML8+ 5?     ?? *Status+   
 5?  &     5?  *   $ LeftMouseDown??69   . 5?  .      6H   ?? *SwitchPage6+5?  +   5?  #   ?? 5?  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5?  &     5?  *   $ MouseDoubleClick??69   . 5?  .      6H   ?? *SwitchPage6+5?  +   5  #   5     ? 5     $??1??6#   $??
50 5 120 5q?63   $	??230??5  #   .+?5  "     $ L3??5  %   $ 	MALL 1000??5	  ,   	 5  %   ?? *ML3+ 5     ?? *Status+   
 5
  &     5  *   $ LeftMouseDown??69   . 5  .      6H   ?? *SwitchPage6+5  +   5  #   ?? 5  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5  &     5  *   $ MouseDoubleClick??69   . 5  .      6H   ?? *SwitchPage6+5  +   5  #   5     5     ? 5      5     ?? 5  "   ?? 5  "   .+?5     ? $??0??6#   $??
120 5 50 5q?63   $	??230??5   #   .+?5!  "     $ L9??5"  %   $ 
JSW 850EII??5%  ,    5#     ?? *Status+   	 5$  %   ?? *ML9+
 5&  &     5'  *   $ LeftMouseDown??69   . 5(  .      6H   ?? *SwitchPage6+5)  +   5,  #   ?? 5-  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5.  &     5/  *   $ MouseDoubleClick??69   . 50  .      6H   ?? *SwitchPage6+51  +   53  #   54     ? 55     $??1??6#   $??
50 5 120 5q?63   $	??230??56  #   .+?57  "     $ L2??58  %   $ 	MALL 1000??5;  ,   	 59  %   ?? *ML2+ 5:     ?? *Status+   
 5<  &     5=  *   $ LeftMouseDown??69   . 5>  .      6H   ?? *SwitchPage6+5?  +   5B  #   ?? 5C  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5D  &     5E  *   $ MouseDoubleClick??69   . 5F  .      6H   ?? *SwitchPage6+5G  +   5I  #   5J     5K     ? 5L      5M     ?? 5N  "   ?? 5O  "   .+?5Q     ? $??0??6#   $??
120 5 50 5q?63   $	??230??5R  #   .+?5S  "     $	 L10??5W  %   $ JSW J850E-C5??5X  ,    5U     ?? *Status+   	 5V  %   ?? *ML10+
 5Y  &     5Z  *   $ LeftMouseDown??69   . 5[  .      6H   ?? *SwitchPage7+5\  +   5_  #   ?? 5`  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5a  &     5b  *   $ MouseDoubleClick??69   . 5c  .      6H   ?? *SwitchPage7+5d  +   5f  #   5g     ? 5h     $??1??6#   $??
50 5 120 5q?63   $	??230??5i  #   .+?5j  "     $ L1??5k  %   $ MALL 800??5n  ,   	 5l  %   ?? *ML1+ 5m     ?? *Status+   
 5o  &     5p  *   $ LeftMouseDown??69   . 5q  .      6H   ?? *SwitchPage7+5r  +   5u  #   ?? 5v  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5w  &     5x  *   $ MouseDoubleClick??69   . 5y  .      6H   ?? *SwitchPage7+5z  +   5|  #   5}     5~     ? 5      5?     ?? 5?  "   ?? 5?  "   .+?5?     ? $??0??6#   $??
120 5 50 5q?63   $	??230??5?  #   .+?5?  "     $	 L11??5?  %   $ 
JSW 850EII??5?  ,    5?     ?? *Status+   	 5?  %   ?? *ML11+
 5?  &     5?  *   $ LeftMouseDown??69   . 5?  .      6H   ?? *SwitchPage7+5?  +   5?  #   ?? 5?  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5?  &     5?  *   $ MouseDoubleClick??69   . 5?  .      6H   ?? *SwitchPage7+5?  +   5?  #   5?     5?     ? 5?      5?     ?? 5?  "   ?? 5?  "   .+?5?     ? $??0??6#   $??
120 5 50 5q?63   $	??230??5?  #   .+?5?  "     $	 L12??5?  %   $ MALL 700??5?  ,    5?     ?? *Status+   	 5?  %   ?? *ML12+
 5?  &     5?  *   $ LeftMouseDown??69   . 5?  .      6H   ?? *SwitchPage7+5?  +   5?  #   ?? 5?  "   ???	#004899EA???	#004899EA???	#00F9FEF9
 5?  &     5?  *   $ MouseDoubleClick??69   . 5?  .      6H   ?? *SwitchPage7+5?  +   5?  #   5?     ? 5?     $??1??6#   $??
50 5 120 5q?63   $	??230??5?  #   5?     5?     5?     5?     5?     5?       5?  
   $??1??6   $??Right=?5?     $	??2 5q?5?     ??5?     ?? $ UObservation??$ ActualWidth? 
  $
 0.39??.??5?     ?? $??	47,67,0,0q?6   .+?5?     ? $??65??5?     $??0 30 0 0q?5?     ??5?     ?? $ UObservation??$ ActualWidth? 
  $
 0.39??.+?5?     ?? $??65??6   $(??"Trạng thái đang hoạt động??5?     $??35(?5?     $??SemiBold"?5?     $
??Left=?5?     $
??10 0q?5?     6,   5?     ? 5?     $??35??5?     $??0 10 0 0q?5?     ??5?     ?? $ UObservation??$ ActualWidth? 
  $
 0.39??.+?5?     ?? 
??? ? ?$??35??6-   $??35??5?      $
??Left=?5?      $
??40 0q?5?      60   ?? 5?     $??35??6   $??Đang hoạt động??5?     $??25(?5?     $
??Left=?5?     $
??80 0q?5?     6,   5?     ? 5?     $??35??5?     $??0 10 0 0q?5?     ??5?     ?? $ UObservation??$ ActualWidth? 
  $
 0.39?? 5?     ?? 5?     $??7* ?6+   ?? 5?     $	??19* ?6+   5?     ? 5?     $??35??5?     $??0 10 0 0q?5?     ??5?     ?? $ UObservation??$ ActualWidth? 
  $
 0.39??.+?5?     ?? 
??? ???$??35??6.   $??35??5?      $
??Left=?5?      $
??40 0q?5?      60   ?? 5?     $??35??6   $-??'Cấp điện chuẩn bị sản xuất??5?     $??25(?5?     $
??Left=?5?     $
??80 0q?5?     6,   5?     ? 5?     $??35??5?     $??0 10 0 0q?5?     ??5?     ?? $ UObservation??$ ActualWidth? 
  $
 0.39??.+?5      ?? 
???????$??35??6,   $??35??5      $
??Left=?5      $
??40 0q?5      60   ?? 5     $??35??6   $??Mất kết nối??5     $??25(?5     $
??Left=?5     $
??80 0q?5     6,   5	     ? 5
     $??35??5     $??0 10 0 0q?5     ??5
     ?? $ UObservation??$ ActualWidth? 
  $
 0.39??.+?5     ?? 
???  ??$??35??6+   $??35??5      $
??Left=?5      $
??40 0q?5      60   ?? 5     $??35??6   $"??Dừng do lỗi hệ thống??5     $??25(?5     $
??Left=?5     $
??80 0q?5     6,   5     5     5     5     5!     