   M S B A M L   `   `   `  ����G  CPhotoGallery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PhotoGalleryPhotoGallery  5   	       PhotoGallery.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PhotoGallery     5   	   -   5        $��PhotoGalleryWindow��5   7     � Title$  PhotoGallery��6	   $	��450��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�6Q    � 	Resources 5
       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   '��       �� 5      " ��6
    5      P� 5       �@J�IsKeyboardFocusWithin . . �5      ��  �@��
IsSelected . 6$   5      5      5      .��5      � 	 � RowDefinitions	 5      �� 5      $
��Auto �6   �� 5      .+�5      o� $��0��6	   .@�5      m� $��_File��6   .@�5      m� -   5        $
��_New��5      6   m� 5      -   5        $��_Open...��5      6!   m� 5      -   5        $��_Save��5      6   m� 5      -   5        $��Save _as...��5      6$   m� 5       -   5        $��_Exit��5       6   5!      m� 5"      $��_Edit��6   .@�5#      m� -   5        $��Add f_ile...��5#      6%   m� 5$      -   5        $��Add f_older...��5$      6'   5%      m� 5&      $��_View��6   .@�5'      m� 
 m� IsCheckable
 . $��_Tiles��6"   m� 5(      
 . $��_Small icons��6"   m� 5)      
 . $��_Details��6"   5*      m� 5+      $��_About��6   5,      �� 5.      -	   5        $��
lbPictures��5.      $��1��6    J� 	AllowDrop . $��Disabled=�6b   ��6+   ��  �� Path$ pictures���5/      �� 50      .R�51      � 52      ��55      �� 57      .R�59      �� -
   5        
������ $��0q�59   '   ��5:      �� 5;   	    �� 
TargetType" ��6   .R�5<   
   �� ._�5=      ��    imgStyle#��[  6$   ��6   �� 6$   5?      5@   
   5B      5D      5G      5I      5J      