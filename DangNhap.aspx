<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="DangNhap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

	<link href="https://fonts.googleapis.com/css?family=Lato:300,400,700&display=swap" rel="stylesheet">

	<%--<link rel="stylesheet" href="resource/login/css/font-awesome.min.css">--%>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
	
	<link rel="stylesheet" href="resource/login/css/style.css">
</head>
<body>
    <form id="form1" runat="server">
    <section class="ftco-section">
		<div class="container">
			
			<div class="row justify-content-center">
				<div class="col-md-7 col-lg-5">
					<div class="wrap">
						<div class="img" style="background-image: url(resource/login/images/bg-1.jpg);"></div>
						<div class="login-wrap p-4 p-md-5">
			      	<div class="d-flex">
			      		<div class="w-100">
			      			<h3 class="mb-4">Đăng nhập</h3>
                            <asp:Label ID="lblThongBao" runat="server" Text="Label" Visible="False" ForeColor="#CC3300"></asp:Label>
			      		</div>
								
			      	</div>
                        <asp:Panel ID="panel1" runat="server" CssClass="login100-form validate-form" 
                    DefaultButton="btnLogin">
			      		<div class="form-group mt-3">
                            <asp:TextBox ID="txtTaiKhoan" runat="server" CssClass="form-control" placeholder="Tài khoản"></asp:TextBox>
			      			
			      		</div>
		            <div class="form-group">
                      <asp:TextBox ID="txtMatKhau" runat="server" CssClass="form-control" placeholder="Mật khẩu" TextMode="Password"></asp:TextBox>
		              <span toggle="#txtMatKhau" class="fa fa-fw fa-eye field-icon toggle-password"></span>
		            </div>
		            <div class="form-group">
                        <asp:LinkButton ID="btnLogin" runat="server" 
                            CssClass="form-control btn btn-primary rounded submit px-3" 
                            onclick="btnLogin_Click" >Đăng nhập</asp:LinkButton>
		            </div>
		            <div class="form-group d-md-flex">
		            	<div class="w-50 text-left">
			            	<label class="checkbox-wrap checkbox-primary mb-0">Remember Me
									  <input type="checkbox" checked>
									  <span class="checkmark"></span></label>
						</div>
									
		            </div>
		          </asp:Panel>
		          
		        </div>
		      </div>
				</div>
			</div>
		</div>
	</section>

	<script src="resource/login/js/jquery.min.js"></script>
  <script src="resource/login/js/popper.js"></script>
  <script src="resource/login/js/bootstrap.min.js"></script>
  <script src="resource/login/js/main.js"></script>
    </form>
</body>
</html>
