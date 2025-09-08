import { describe, it, expect } from 'vitest'
import router from '@/router'

describe('Router', () => {
  it('has a root route', () => {
    const route = router.getRoutes().find(r => r.path === '/')
    expect(route).toBeDefined()
  })
})
