   M S B A M L   `   `   `  ����I  EClinicaPOEDS19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClinicaPOEDS19ClinicaPOEDS19  5   	   X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4bCclr-namespace:Xceed.Wpf.Toolkit.Obselete;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit.Obselete 5   @        ClinicaPOEDS19.frmPaciente   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClinicaPOEDS19     5   	   4xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   RObseleteCclr-namespace:Xceed.Wpf.Toolkit.Obselete;assembly=Xceed.Wpf.Toolkit  6@     N� Title$  frmPaciente��5	   	   $	��578��6   $��884.571��6*   .��5
      � $��0,0,-105.6,-59q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgPacientes��5      $
��Left=�6(   $	��188��6C   $��
23,341,0,0q�6P   $	��Top=�6d   $	��650��6|   6�   �� 5   
   -   5         ��Name$ 
btnAgregar��5      $��Agregar��6%   $
��Left=�67   $��
712,71,0,0q�6S   $	��Top=�6g   $��32��6   $��94��6�   6�   �� 5   
   -   5        $ btnModificar��5      $��	Modificar��6'   $
��Left=�6;   $��32��6V   $��712,122,0,0q�6b   $	��Top=�6w   $��94��6�   6�   �� 5   
   -   5        $ btnEliminar��5      $��Eliminar��6&   $
��Left=�69   $��712,172,0,0q�6T   $	��Top=�6i   $��32��6�   $��94��6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ FechaNacimiento��5      $
��Left=�6.   $��183,190,0,0q�6I   $	��Top=�6^   $��94��6v   $��32��6�    J� RenderTransformOrigin$ -0.191,0.514&�6�   	� 5   
   -   5         	�Name$ rdbSexo��5       	� 	GroupName$	 sex��6'   $��	Masculino��67   $��Right=�6K   $��32��6g   $��0,245,674,0q�6s   $	��Top=�6�   $	��127��6�   $ 1.913,0.504&�6�    d� 	IsChecked$
 TrueY�6�   8  2Xceed.Wpf.Toolkit.Zoombox.ZoomboxViewFinderDisplay  5   
   $
��Left=�6(   $	��100��6C   $��
588,10,0,0q�6P   $	��Top=�6d   $	��100��6|   .  (Xceed.Wpf.Toolkit.Obselete.MaskedTextBox  5   
   -   5          Name$ txtDUI��5   !   $��Right=�61   $��23��6M   $��0,140,680.6,0q�6Y   	 �� TextWrapping$
	 Wrap=�6p   $��MaskedTextBox��6�   $	��Top=�6�   $	��120��6�   
   Mask$
 
00000000-0��6�   �� 5   
   -   5         ��Name$ lblDUI��5      $��Número DUI:��6    $
��Left=�66   $��
50,140,0,0q�6Q   $	��Top=�6e   �� 5   
   -	   5        $ 	lblGenero��5      $��Sexo:��6#   $��Right=�63   $��0,253,898,0q�6O   $	��Top=�6d   $ 2.513,0.919&�6|   	� 5   
   -
   5        $ rdbSexo2��5      $	 sex��6)   $��Femenino��6:   $��Right=�6M   $��0,295,727,0q�6i   $	��Top=�6~   $ -0.279,0.61&�6�   �� 5   
   -   5        $ 	lblNombre��5      $��Nombre Completo:��6#   $
��Left=�6>   $��	50,86,0,0q�6Y   $	��Top=�6l   �� 5   
   -   5         ��Name$ 	txtNombre��5      $
��Left=�6%   $��23��6@   $��
183,87,0,0q�6L   $
	 Wrap=�6`   $	��Top=�6t   $	��318��6�   �� 5   
   -   5        $ lblFnac��5      $��Fecha Nacimiento:��6!   $
��Left=�6=   $��
50,199,0,0q�6X   $	��Top=�6l   $ -0.246,0.257&�6�   �� 5   
   -   5        $ btnClear��5      $��Reset��6#   $
��Left=�63   $��712,223,0,0q�6N   $	��Top=�6c   $��94��6{   6�   �� 5   
   $��GESTION DE PACIENTES��6   $
��Left=�6/   $��
334,28,0,0q�6J   $	��Top=�6^   $
��Bold"�6v   $��16(�6�   $	��254��6�   5      5      