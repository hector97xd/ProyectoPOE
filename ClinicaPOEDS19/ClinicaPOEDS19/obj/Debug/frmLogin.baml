   M S B A M L   `   `   `  ����I  EClinicaPOEDS19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClinicaPOEDS19ClinicaPOEDS19  5   	       ClinicaPOEDS19.MainWindow   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   (localclr-namespace:ClinicaPOEDS19  5   	     � Title$!  Identificación de usuarios��5	   	   $	��500��6,   $	��350��69    � 
ResizeMode$ NoResize=�6E    � WindowStartupLocation$ CenterScreen=�6[    � WindowStyle$
 None=�6�   .��5
      � .+�5   
   �� $	��280��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF2281D1��6#   � 5      $ 	#FF34268A��6#    � Offset$ 1Q�65   � 5      $ 	#FF33288B��6#   $	 0.5Q�65   5      5      �� 5   
   $��logo.png��6   $��20q�6"   $	��100��6.   $	��100��6:   $	��Top=�6G    K� ZIndex$ 20��6_   �� 5   
   $	��280��6   $	��240��6    
�������$��Bottom=�6:   $��0,100q�6U   	 �� RadiusX$	 10��6d   
 �� RadiusY$
 10��6q    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      Color$ 	#FFBBBBBB��63      	Direction$ 0Q�6E      RenderingBias$ Quality=�6S      ShadowDepth$ 1Q�6k   5      � 5   
   $	��280��6   $	��240��6   $��Bottom=�6(   $��0,100q�6C   .+�5      �� $��LOGIN��6   $��Center=�6$   $	��Top=�6A   $��5q�6Y   
�������$��18(�5   &   �� 5      $��Center=�6   $��15q�64   .+�5       �� -   5         ��Name$ 
txtUsuario��5       $
��0,10q�5!      $��18(�5"      $��Champagne & Limousines)�5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Usuario��5$       %  !MaterialDesignFloatingHintTextBox#��[  5%      G� 5'      -   5         G�Name$ txtClave��5'      $
��0,10q�5(      $��18(�5)      $��Champagne & Limousines)�5*      $ Contraseña��5+       ) %MaterialDesignFloatingHintPasswordBox#��[ 5,      5.      5/      �� 50   
   -   5         ��Name$ btnIngresar��50      $��Ingresar��6&   $	��150��69   $��Center=�6E   $��Bottom=�6b   $
��0,85q�6}   6�   53      54      