   M S B A M L   `   `   `  ����H  DSaveTheHumans, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SaveTheHumansSaveTheHumans  5   	       SaveTheHumans.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SaveTheHumans     5   	     � Title$  Save the Humans��5   	   $	��700��6!   $
��1000��6.    � 	Resources 5	         EnemyTemplate �� 
TargetType J� RenderTransformOrigin �� AngleX��%�  &	        �� 5
   
   " ��60   .R�5      � .+�5      A� 
�������$	��100��6&   
���   �$��75��6B   A� 5      
���   �$
��Left=�6'   $��35��6B   $��
40,20,70,0q�6N   
���   �$	��Top=�6q   $��25��6�   $ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      $ 10Q�6,   �� 5      T� 5      5      5      A� 5      
���   �$
��Left=�6'   $��35��6B   $��
70,20,40,0q�6N   
���   �$	��Top=�6q   $��25��6�   $ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      $	 -10Q�6,   �� 5      T� 5      5      5       5!      5"      5#      .��5$      � -   5         �Name$
 grid��5$      
���   � � ColumnDefinitions 5%   
   �� 5&      $	��140 �6   �� 5'      �� 5(      $	��160 �6    � RowDefinitions 5*   
   �� 5+      �� 5,      $	��150 �6   .+�5.   
   �� -   5         ��Name$ startButton��5.      $��Start!��6&   $��Center=�67   $��1��6T   $��Center=�5/      $��75��6,   67   � 50   
   -   5        	 �Name$	 progressBar��50      $��1��6+   $��1��6;   $��20��6H   �� 51   
   -   5        
 ��Name$
 playArea��51      $��3��6#   ��52      �� 53       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��54      �  � Color$ Black��6#    � Offset$ 0Q�61   � 55      $ Black��6#   $ 1Q�61   � 56      $ 	#FF00889E��6#   $ 0.542Q�65   57      .+�59      �� -   5         ��Name$ human��59       �� Orientation$ Vertical=�6(    �� Left$	 305��6[   
 �� Top$	 330��6m   .+�5:      A� 
�������$��10��6'   
���   �$��10��6B   �� 5;      
�������$��25��6)   
���   �$��10��6D   5<      �� 5=      -   5         ��Name$ gameOverText��5=      $��162.533��6.   $ 222.69��6?   $
��Wrap=�6T   $��	Game Over��6h   $ 184.436��6y   $��564.585��6�   $��Arial)�6�   $	��100(�6�   $
��Bold"�6�   $��Italic$�6�   �� 5>      -   5         ��Name$ target��5>      $��50��6(   
���   �$��50��6C   $ 0.5,0.5&�6N   $	 675��6n   $	 325��6�   z�5?      V� 5@      .~�5A      �� �� 5B      �� 5C       �� Angle$ 45Q�6*   T� 5D      5E      ��5G      �� 5H      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5I      � $ Black��6'   $ 0Q�65   � 5J      $ White��6'   $ 1Q�65   5K      5M      5N      �� 5O   
   $��2��6   $ Vertical=�6%   $��1��6<   $��Center=�6I   $��Center=�6f   .+�5P      �� $
��Wrap=�5Q      $��Avoid These��5R      $��18(�6$   $��Center=�62   $��Center=�6O   
�������6j   �� 5S      $��ContentControl��6   $��Center=�66   $��Center=�5T      #���   68   5U      5W      5X      