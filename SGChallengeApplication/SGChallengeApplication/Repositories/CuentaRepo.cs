using SGChallengeApplication.Data.Models;
using SGChallengeApplication.Models;
using SGChallengeApplication.Repositories.Interfaces;

namespace SGChallengeApplication.Repositories
{
    public class CuentaRepo : ICuentaRepo
    {
        private readonly ChallengeSgContext _context;
        private Random _random = new Random();

        public CuentaRepo(ChallengeSgContext context)
        {
            _context = context;
        }

        public void CrearCuenta(Cuenta cuenta)
        {
            if (cuenta == null)
            {
                throw new ArgumentNullException(nameof(cuenta));
            }
            else
            {
                _context.Cuenta.Add(cuenta);
                _context.SaveChanges();
            }
        }

        public Cuenta? RetirarSaldo (int idCuenta, decimal monto)
        {
            var cuenta = (from c in _context.Cuenta

                          where c.Id == idCuenta

                          select c).FirstOrDefault();

            if (cuenta == null)
            {
                return null;
            }
            else
            {
                cuenta.Saldo = cuenta.Saldo - monto;

                _context.SaveChanges();
                return cuenta;   
            }
        }

        public Cuenta? DepositarSaldo(int idCuenta, decimal monto)
        {
            var cuenta = (from c in _context.Cuenta

                          where c.Id == idCuenta

                          select c).FirstOrDefault();

            if (cuenta == null)
            {
                return null;
            }
            else
            {
                cuenta.Saldo = cuenta.Saldo + monto;

                _context.SaveChanges();
                return cuenta;
            }
        }

        public Cuenta? TraerCuentaPorId(int idCuenta)
        {
            var cuenta = (from c in _context.Cuenta
                          join tc in _context.TipoCuenta on c.IdTipoCuenta equals tc.Id
                          join cli in _context.Clientes on c.IdCliente equals cli.Id
                          join td in _context.TipoDocumentos on cli.IdTipoDocumento equals td.Id
                          join l in _context.Localidads on cli.IdLocalidad equals l.Id
                          join p in _context.Provincia on l.IdProvincia equals p.Id
                          join ps in _context.Pais on p.IdPais equals ps.Id
                          join m in _context.Moneda on c.IdMoneda equals m.Id
                          join s in _context.Sucursals on c.IdSucursal equals s.Id
                          join b in _context.Bancos on s.IdBanco equals b.Id

                          where c.Id == idCuenta

                          select new Cuenta
                          {
                              Id = c.Id,
                              NroCuenta = c.NroCuenta,
                              Cbu = c.Cbu,
                              Alias = c.Alias,
                              Saldo = c.Saldo,
                              Activo = c.Activo,
                              IdTipoCuenta = c.IdTipoCuenta,
                              IdCliente = c.IdCliente,
                              IdMoneda = c.IdMoneda,
                              IdSucursal = c.IdSucursal
                              
                          }).FirstOrDefault();

            return cuenta;
        }

        public IEnumerable<Cuenta> TraerCuentas()
        {
            var cuentas = (from c in _context.Cuenta
                           join tc in _context.TipoCuenta on c.IdTipoCuenta equals tc.Id
                           join cli in _context.Clientes on c.IdCliente equals cli.Id
                           join td in _context.TipoDocumentos on cli.IdTipoDocumento equals td.Id
                           join l in _context.Localidads on cli.IdLocalidad equals l.Id
                           join p in _context.Provincia on l.IdProvincia equals p.Id
                           join ps in _context.Pais on p.IdPais equals ps.Id
                           join m in _context.Moneda on c.IdMoneda equals m.Id
                           join s in _context.Sucursals on c.IdSucursal equals s.Id
                           join b in _context.Bancos on s.IdBanco equals b.Id

                           select new Cuenta
                           {
                               Id = c.Id,
                               NroCuenta = c.NroCuenta,
                               Cbu = c.Cbu,
                               Alias = c.Alias,
                               Saldo = c.Saldo,
                               Activo = c.Activo,
                               IdTipoCuenta = c.IdTipoCuenta,
                               IdCliente = c.IdCliente,
                               IdMoneda = c.IdMoneda,
                               IdSucursal = c.IdSucursal

                           }).ToList();

            return cuentas;
        }
    }
}
