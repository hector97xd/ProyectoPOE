   M S B A M L   `   `   `  ����I  EClinicaPOEDS19, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClinicaPOEDS19ClinicaPOEDS19  5   	   #    ClinicaPOEDS19.frmDiagnostico   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ClinicaPOEDS19     5   	     N� Title$  frmDiagnostico��5   	   $��652.572��6    $��736.334��61   .��5	      � .+�5
   
   �� $��Fecha ingreso��6   $
��Left=�6(   $��	50,79,0,0q�6C   $	��Top=�6V   �� 5   
   $��Doctor��6   $
��Left=�6!   $��
50,348,0,0q�6<   $	��Top=�6P   �� 5   
   $��Paciente��6   $
��Left=�6#   $��
50,310,0,0q�6>   $	��Top=�6R    J� RenderTransformOrigin$ 0.537,1.992&�6j   �� 5   
   $��Tratamiento��6   $
��Left=�6&   $��
50,214,0,0q�6A   $	��Top=�6U   �� 5   
   $��Descripcion��6   $
��Left=�6&   $��
50,129,0,0q�6A   $	��Top=�6U   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpFecha��5      $
��Left=�6&   $��
190,79,0,0q�6A   $	��Top=�6U   $	��185��6m   �� 5   
   -   5         ��Name$ txtDecripcion��5      $
��Left=�6-   $��84��6H   $��190,112,0,0q�6T   $	��Top=�6i   $	��267��6�   . �5      /� .T�5      J� .*�6   .*�5      �� $� ��6   5      5      5      �� 5   
   -   5        $ txtTratamiento��5      $
��Left=�6.   $��78��6I   $��190,214,0,0q�6U   $	��Top=�6j   $	��267��6�   . �5      /� .T�5      J� .*�6   .*�5      �� $� ��6   5      5      5      �� 5   
   -   5         ��Name$ cmbPaciente��5      $
��Left=�6(   $��190,310,0,0q�6C   $	��Top=�6X   $	��185��6p   �� 5    
   -   5        $ 	cmbDoctor��5       $
��Left=�6&   $��190,348,0,0q�6A   $	��Top=�6V   $	��185��6n   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dgDiagnostico��5!      $
��Left=�6*   $	��206��6E   $��
10,407,0,0q�6R   $	��Top=�6f   $	��713��6~   6�   �� 5"   
   -   5         ��Name$ btnInsertar��5"      $��Guardar��6&   $
��Left=�68   $��
490,90,0,0q�6S   $	��Top=�6g   $��97��6   $ 0.559,-0.031&�6�   6�   �� 5#   
   -   5        $ 
btnLimpiar��5#      $��Limpiar��6%   $
��Left=�67   $��490,206,0,0q�6R   $	��Top=�6g   $��97��6   $ 0.559,-0.031&�6�   6�   �� 5$   
   -	   5        $ btnEliminar��5$      $��Eliminar��6&   $
��Left=�69   $��490,147,0,0q�6T   $	��Top=�6i   $��97��6�   $ 0.559,-0.031&�6�   6�   �� 5%   
   $��DIAGNOTICO DE CLIENTES��6   $
��Left=�61   $��
270,20,0,0q�6L   $	��Top=�6`   $	��233��6y   $��16(�6�   $��29��6�   $
��Bold"�6�   z�5&      V� 5'      .~�5(      �� �� 5)      �� 5*       �� Angle$ 0.708Q�6&   T� 5+      5,      5.      �� 5/   
   -
   5        $ 
btnReporte��5/      $��Reporte diagnostico��6%   $
��Left=�6C   $��490,270,0,0q�6^   $	��Top=�6s   $	��165��6�   $ 0.559,-0.031&�6�   6�   52      53      