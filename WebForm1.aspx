<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm1.aspx.cs" Inherits="WebForm1" %>

<html xmlns="http://www.w3.org/1999/xhtml">

   <head runat="server">
      <title>VIETSUGAR</title>
       <link rel="stylesheet" href="Styles/bai9.css" />
        <style type="text/css">
        
        #img_banner {
            margin-bottom: 0px;
        }
            .auto-style1 {
                font-size: xx-large;
                color: #FF3300;
            }
            .auto-style2 {
                text-align: left;
            }
            #oFile {
                width: 47%;
                height: 10%;
                
            }
    </style>
   </HEAD>
   <body MS_POSITIONING="GridLayout">
       <form id="Form1" runat="server" margin="20px" >
          <header class="row" style="color: #000000; font-weight: 700;">
              <br />
              CÔNG TY CỔ PHẦN ĐƯỜNG VIỆT NAM<br />
              <span class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; VIETSUGAR</span><br />
           
        </header>
           <br />
            <div class="page">
         Image file to upload to the server:<br />
           <div>
               <asp:FileUpload ID="FileUpload1" runat="server" BackColor="#0066FF" Height="75px" Width="333px" BorderStyle="Double" EnableTheming="True" Font-Size="Large" ViewStateMode="Enabled" />
               <INPUT id="oFile" type="file" runat="server" NAME="oFile" BackColor="#0066FF" visible="False"  >
           </div>     
           <div>
               
               <asp:Image ID="Image1" runat="server" Height="529px" Width="526px" BorderStyle="Groove" />
           </div>
           <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="UPLOAD" Height="72px" Width="164px" />
              &nbsp;<asp:Panel ID="frmConfirmation" Visible="False" Runat="server">
            <asp:Label id="lblUploadResult" Runat="server"></asp:Label>
                    <br />
         </asp:Panel>
                <span class="tieude">Read details Image</span>
                 <p>
                     Read details Image</p>
           <div class="auto-style2">
               KINH TUYẾN
               <asp:TextBox ID="TextBox1" runat="server" Font-Size="Large" Height="33px" Width="273px"></asp:TextBox>
           </div>
                <p></p>
            <div class="auto-style2">
               VĨ TUYẾN&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" Height="32px" Font-Size="Large" Width="270px"></asp:TextBox>
            </div>
                <p></p>
              <div class="auto-style2">  
               NGÀY MDF&nbsp;&nbsp;&nbsp;
               <asp:TextBox ID="TextBox3" runat="server" Font-Size="Large" Height="31px" Width="265px"></asp:TextBox>          
           </div>
       </form>
   </body>
</HTML>