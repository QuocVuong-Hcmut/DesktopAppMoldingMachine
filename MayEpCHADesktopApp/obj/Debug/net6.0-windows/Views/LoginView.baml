   M S B A M L   `   `   `  ????R  NMayEpCHADesktopApp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?Uclr-namespace:MayEpCHADesktopApp.Core.ValueConverter;assembly=MayEpCHADesktopApp.Core&MayEpCHADesktopApp.Core.ValueConverter  5
       MayEpCHADesktopApp(   "MayEpCHADesktopApp.Views.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hi:http://schemas.microsoft.com/expression/2010/interactivity     5      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      e	ConverterUclr-namespace:MayEpCHADesktopApp.Core.ValueConverter;assembly=MayEpCHADesktopApp.Core  5
      -   5          >?Name$  ULogin??5         MaterialDesignBody#???   5      $??Regular"?5      $??13(?5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper#???  5        MaterialDesignFont#???  5      $	??824??5      $??1267.2??5      .??5      ? 
???????.+?5   
   ? .+?5      #  MaterialDesignThemes.Wpf.Card  ???	#FF00294D$??Center=?5   "   $??Center=?5   "   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=?5   "   ??5   "   ??  ?? Path$ Width? ?? ElementName$ ULogin?? ?? 	Converter :   4MayEpCHADesktopApp.Core.ValueConverter.SizeConverter   ?? ConverterParameter$	 0.5????5   "   ?? $ Height?$ ULogin??   $	 0.5??.??5      ?  ? 	Resources 5      	 ?? 
TargetType
 ?? Property ?? Value??%b   '?       ?? 5       "	 ?6    .?5!      ?? 
 ? ??$ 	15 0 15 0q?5"   %   69   5#      5$       ? RowDefinitions 5%      ?? 5&      $??2* ?6(   66   ?? 5'      $??2* ?6)   67   ?? 5(      $??2* ?6(   66   ?? 5)      $??4* ?6(   66   .+?5+      ? $??0??6   $??Center=?5,      $??Center=?5-      .+?5.      ?? $??Center=?6$   $??45(?5/   $   
???????$??
0,12,0,-12q?51   $   ?? 69   .?6>   ĐĂNG NHẬP6I   6P   52      ? 53      $??1??6   .+?54      ?? 
???????$??25(?55   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập??56   "    % !MaterialDesignFloatingHintTextBox#??[ 58   "   
?????????57   "   ?? *
UserName+59   "   5:      ? 5;      $??2??6    ? ColumnDefinitions 5<      ?? 5=      $
??299* ?6/   ?? 5>      $
??554* ?6/   .+?5@      G? -   5         G?Name$ FloatingPassWordBox??5B   &   
???????$??25(?5A   &   $ Mật khẩu??5C   &   $??
0,24,0,-24q?5D   &   
???????$??2??5F   &   5G      5H      ? 5I      -   5         ?Name$ Grid1??5J      $??3??5I       5K      ?? 5L      $??* ?6/   6;   ?? 5M      $??* ?6/   6;   .+?5O      ? $??0??6   .+?5P      (? .??5Q   "   ??  " MaterialDesignRaisedDarkButton#??[ 6)   
????? ? ? ToolTip$8 2Resource name: MaterialDesignRaisedLightDarkButton??5S   )   ??5T   )   ?? $ ActualHeight?$ Grid1??   $
 0.25????5U   )   ?? $ ActualWidth?$ Grid1??   $	 0.3????5V   )   ?? $ loginWindow??.??5W   &   (? .??5X   *   ?? 
???????$??20(?5Y   4   Đăng Nhập6M   5Z   '   5[   #   5\      5]      ? 5^      $??1??6   .+?5_      (? .??5`   "   ?? #??[ 6)   
????? ?$8 2Resource name: MaterialDesignRaisedLightDarkButton??5b   )   ??5c   )   ?? $ ActualHeight?$ Grid1??   $
 0.25????5d   )   ?? $ ActualWidth?$ Grid1??   $	 0.3????5e   )   ?? $ loginWindow??.??5f   &   (? .??5g   *   ?? 
???????$??20(?5h   4   Thoát6I   5i   '   5j   #   5k      5l      5m      5n      5o      5p      5q      5r      