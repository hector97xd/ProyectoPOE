   M S B A M L   `   `   `  ����I  EClinicaPOEDS19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClinicaPOEDS19ClinicaPOEDS19  5   	       ClinicaPOEDS19.frmCita   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   (localclr-namespace:ClinicaPOEDS19  5   	   X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          N�Name$  frmCita1��5   @    N� Title$ frmCita��5   	   $��547.5��6   $	��800��6(   .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgcita��5      $
��Left=�6#   $	��254��6>   $��
10,240,0,0q�6K   $	��Top=�6_   $	��772��6w   6�   �� 5   
   -   5         ��Name$ 	cbxDoctor��5   @   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Seleccionar��6   $
��Left=�6S   $��140,120,0,0q�6n   $	��Top=�6�   $	��206��6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        $ cbxPaciente��5   @   $ Seleccionar��6   $
��Left=�6U   $��
140,77,0,0q�6p   $	��Top=�6�   $	��206��6�   �� 5   
   -   5         ��Name$ txtDecripcion��5      $
��Left=�6-   $��58��6H   $��140,162,0,0q�6T   $	��Top=�6i   $	��416��6�   . �5      /� 5      �� 5   
   -   5         ��Name$ btnRegistrar��5      $��Guardar��6'   $
��Left=�69   $��
594,40,0,0q�6T   $	��Top=�6h   $	��144��6�   6�   �� 5   
   -   5        $ btnEliminar��5      $��Eliminar��6&   $
��Left=�69   $��
594,87,0,0q�6T   $	��Top=�6h   $	��144��6�   6�   �� 5   
   -   5        $ btnComprobante��5      $��Comprobante��6)   $
��Left=�6?   $��594,137,0,0q�6Z   $	��Top=�6o   $	��144��6�   6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   -	   5        	  Name$	 	FechaCita��5   O   $ Ingresar Fecha��6   $
��Left=�6b   $��
140,40,0,0q�6}   $	��Top=�6�   $	��206��6�   &   Xceed.Wpf.Toolkit.DateTimeUpDown
   Format$
 Custom=�6�      FormatString$ dd-MMM-yy hh:mm:ss��6�   �� 5   
   $��Fecha de la cita:��6   $
��Left=�6,   $��	29,36,0,0q�6G   $	��Top=�6Z   �� 5   
   $��Asignar doctor:��6   $
��Left=�6*   $��
32,121,0,0q�6E   $	��Top=�6Y   �� 5   
   $��	Paciente:��6   $
��Left=�6$   $��	66,77,0,0q�6?   $	��Top=�6R    J� RenderTransformOrigin$ 1.309,0.833&�6j   �� 5   
   $��Descripción:��6   $
��Left=�6'   $��
49,162,0,0q�6B   $	��Top=�6V   5       5!      