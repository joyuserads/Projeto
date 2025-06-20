export const parseJwt = () => {
  const token = localStorage.getItem('usuario-login');
  if (!token) return null;

  try {
    const base64Url = token.split('.')[1];
    if (!base64Url) return null;

    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const payload = JSON.parse(window.atob(base64));

    // Mapeia a role para payload.role
    payload.role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

    return payload;
  } catch (error) {
    console.error("Erro ao decodificar token:", error);
    return null;
  }
};


export const usuarioAutenticado = () =>
  localStorage.getItem('usuario-login') !== null;
