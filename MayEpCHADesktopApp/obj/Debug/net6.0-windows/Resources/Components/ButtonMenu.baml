   M S B A M L   `   `   `  ????R  NMayEpCHADesktopApp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?Uclr-namespace:MayEpCHADesktopApp.Core.ValueConverter;assembly=MayEpCHADesktopApp.Core&MayEpCHADesktopApp.Core.ValueConverter  5
       MayEpCHADesktopApp8   2MayEpCHADesktopApp.Resources.Components.ButtonMenu   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      k	ConverterUclr-namespace:MayEpCHADesktopApp.Core.ValueConverter;assembly=MayEpCHADesktopApp.Core     5
      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          >?Name$
  Root??5      ??5	      ??  ?? ElementName$
 Root?? ?? Path$ BackgroundBTMenu?.??5      ? ??6   ?? $
 Root??$ ActualHeight???5      ?? $
 Root??$ ActualWidth???5   
   ?? 5       ?? 
TargetType" ?6    ?? Triggers 5      ?? 5       ?? Binding 6"   ?? $
 Root??$ IsMouseOver? ?? Value True5   "   .a?5      ??  ?? Property ? ?? ?? Value
 ??? ?5   7   ?? 5       ?@J?Opacity$ 50Q?5   !   5      5      .+?5   
   ?? -   5        	 ??Name$	 
MainButton??5      
??????    
MenuButton#??[  5"      $??0 0 8 0 q?5#      ??5      ?? $
 Root??$ ActualHeight???5      ?? $
 Root??$ ActualWidth???5$      ?? $ BoderBrushBTMenu?$
 Root????5%      ? 5&      $y?Visible=?6   
?????? ??5(      ?? $
 Root??$ ActualHeight???5)      ?? $
 Root??$ ActualWidth?.+?5*      ? -   5        
 ?Name$
 GridNoClick??5*      
?????? y?5+      ?? $
 Root??$ 
Animation1?   BooleanToVisibilityConverter ?? 	Converter# [ ??5-      ?? $
 Root??$ ActualHeight???5.      ?? $
 Root??$ ActualWidth?.+?5/      ?? 
??????  ?? Orientation$ 
Horizontal=?52   %   ??50   %   ?? $
 Root??$ ActualHeight???51   %   ?? $
 Root??$ ActualWidth?.+?53      '  !MaterialDesignThemes.Wpf.PackIcon  $??0 5 0 -5q?56   7   ??53   7   ?? $
 Root??$ ActualHeight? :   4MayEpCHADesktopApp.Core.ValueConverter.SizeConverter   ?? ConverterParameter$	 0.8????54   7   ?? $
 Root??$ ActualWidth?   $	 0.3????55   7   ?? $ ForegroundPackicon?$
 Root??   Kind 57   7   ?? $ NamePackIcon?$
 Root??6o   ?? 58      
?????? $
??Left=?5>   $   $??Center=?5?   $   ??58   $   ?? $
 Root??$ ContentText???59   $   ?? $
 Root??$ ActualHeight???5:   $   ?? $
 Root??$ ActualWidth?   $	 0.7????5;   $   ?? $
 Root??$ ActualHeight?   $
 0.35????5=   $   ?? $ ForegroundText?$
 Root??5?   H   5@      5A      ? 5B      -   5        $
 	GridClick??5B      
?????? y?5C      ?? $
 Root??$ 
Animation2?# [ ??5E      ?? $
 Root??$ ActualHeight???5F      ?? $
 Root??$ ActualWidth?.+?5G      ?? 
?????? $ 
Horizontal=?5J   &   ??5H   &   ?? $
 Root??$ ActualHeight???5I   &   ?? $
 Root??$ ActualWidth?.+?5K      ?? $??	0 -5 0 5 q?5M   $   $	??184??5N   $   
?????? 
???????$??Center=?5R   $   $??Center=?5S   $   ??5K   $   ?? $
 Root??$ ContentText???5L   $   ?? $
 Root??$ ActualHeight???5O   $   ?? $
 Root??$ ActualHeight?   $	 0.4??5S   H     5T      
???????$??0 0 0 0q?5W   8   ??5T   8   ?? $
 Root??$ ActualHeight?   $	 0.8????5U   8   ?? $
 Root??$ ActualWidth?   $	 0.3?? 5X   8   ?? $ NamePackIcon?$
 Root??6p   5Y      5Z      5[      5]      ?? 5^   
   $??1??6   $??Bottom=?5`      ???	#FF838156??5_      ?? $
 Root??$ ActualWidth?5a   '   5b      5c      